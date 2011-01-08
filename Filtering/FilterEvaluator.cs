// Copyright 2008-2010 Andrej Repin aka Gremlin2
// 
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
// 
//        http://www.apache.org/licenses/LICENSE-2.0
// 
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// 
using System;
using System.Collections;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;

using DevExpress.Data.Filtering;
using DevExpress.Data.Filtering.Helpers;

namespace Gremlin.FB2Librarian.Import.Filtering
{
    internal class FilterEvaluator : IClientCriteriaVisitor
    {
        private readonly IClientCriteriaVisitor evaluatorCore;
        private readonly EvaluatorContextDescriptor descriptor;
        private readonly CriteriaOperator filterCriteria;
        private readonly FieldInfo contexts;
        private readonly LikeDataCache likeDataCache;

        public FilterEvaluator(PropertyDescriptorCollection properies, CriteriaOperator filterCriteria) : this(new EvaluatorContextDescriptorDefault(properies), filterCriteria)
        {
        }

        public FilterEvaluator(PropertyDescriptorCollection properies, string filterCriteria) : this(new EvaluatorContextDescriptorDefault(properies), CriteriaOperator.Parse(filterCriteria, new object[0]))
        {
        }

        public FilterEvaluator(EvaluatorContextDescriptor descriptor, string filterCriteria) : this(descriptor, CriteriaOperator.Parse(filterCriteria, new object[0]))
        {
        }

        public FilterEvaluator(EvaluatorContextDescriptor descriptor, CriteriaOperator filterCriteria)
        {
            this.evaluatorCore = new ExpressionEvaluatorCore(true);
            this.descriptor = descriptor;
            this.filterCriteria = filterCriteria;

            this.contexts = typeof (ExpressionEvaluatorCore).GetField("contexts", BindingFlags.Instance | BindingFlags.NonPublic);

            FieldInfo fieldInfo = typeof(ExpressionEvaluatorCore).GetField("LikeDataCache", BindingFlags.Instance | BindingFlags.NonPublic);
            likeDataCache = (LikeDataCache) fieldInfo.GetValue(this.evaluatorCore);
        }

        public bool Fit(object value)
        {
            return Fit(new EvaluatorContext(descriptor, value));
        }

        private bool Fit(EvaluatorContext evaluationContext)
        {
            return (bool) Evaluate(evaluationContext);
        }

        public object Evaluate(EvaluatorContext evaluationContext)
        {
            try
            {
                this.contexts.SetValue(evaluatorCore, new[] {evaluationContext});
                return Accept(filterCriteria);
            }
            finally
            {
                this.contexts.SetValue(evaluatorCore, null);
            }
        }

        private object Accept(CriteriaOperator criteriaOperator)
        {
            if (ReferenceEquals(criteriaOperator, null))
            {
                return null;
            }

            object value = criteriaOperator.Accept(this);
            return value == DBNull.Value ? null : value;
        }

        private static int Compare(object left, object right, bool isEqualityCompare)
        {
            if (left == null)
            {
                if (right != null)
                {
                    return -1;
                }
                return 0;
            }
            if (right == null)
            {
                return 1;
            }

            IList leftList = left as IList;
            if(leftList != null)
            {
                foreach (object leftItem in leftList)
                {
                    if(Compare(leftItem, right, isEqualityCompare) == 0)
                    {
                        return 0;
                    }
                }

                return 1;
            }

            Type rightType = right.GetType();
            Type leftType = left.GetType();

            if (rightType == typeof (string))
            {
                left = left.ToString();
            }
            else
            {
                right = ConvertValue(right, rightType, leftType);
            }

            if (leftType == typeof (string))
            {
                return String.Compare((string) left, (string) right, false, CultureInfo.InvariantCulture);
            }

            if (isEqualityCompare)
            {
                return left.Equals(right) ? 0 : -1;
            }

            return Comparer.Default.Compare(left, right);
        }

        private static object ConvertValue(object val, Type valType, Type type)
        {
            if (valType == type)
            {
                return val;
            }

            if (type.IsEnum)
            {
                if (valType == typeof (String))
                {
                    return Enum.Parse(type, (string) val, false);
                }

                return Enum.ToObject(type, val);
            }

            if (val is IConvertible)
            {
                return Convert.ChangeType(val, type, CultureInfo.InvariantCulture);
            }

            return val;
        }


        public object Visit(BetweenOperator theOperator)
        {
            object left = Accept(theOperator.TestExpression);

            if (Compare(left, Accept(theOperator.BeginExpression), false) < 0)
            {
                return false;
            }

            if (Compare(left, Accept(theOperator.EndExpression), false) > 0)
            {
                return false;
            }

            return true;
        }

        public object Visit(BinaryOperator theOperator)
        {
            switch (theOperator.OperatorType)
            {
                case BinaryOperatorType.Equal:
                case BinaryOperatorType.NotEqual:
                case BinaryOperatorType.Like:
                    object left = Accept(theOperator.LeftOperand);
                    object right = Accept(theOperator.RightOperand);

                    switch (theOperator.OperatorType)
                    {
                        case BinaryOperatorType.Equal:
                            return (Compare(left, right, true) == 0);
                        
                        case BinaryOperatorType.NotEqual:
                            return (Compare(left, right, true) != 0);

                        case BinaryOperatorType.Like:
                            if(left != null && right != null)
                            {
                                IList leftList = left as IList;

                                if (leftList != null)
                                {
                                    foreach (object leftItem in leftList)
                                    {
                                        if(this.likeDataCache[right.ToString()].Fit(leftItem.ToString()))
                                        {
                                            return true;
                                        }
                                    }
                                }

                                return this.likeDataCache[right.ToString()].Fit(left.ToString());
                            }

                            return false;
                    }
                    return evaluatorCore.Visit(theOperator);

                default:
                    return evaluatorCore.Visit(theOperator);
            }
        }

        public object Visit(UnaryOperator theOperator)
        {
            switch(theOperator.OperatorType)
            {
                case UnaryOperatorType.Not:
                    object operand = this.Accept(theOperator.Operand);
                    if (operand != null)
                    {
                        return !((bool)operand);
                    }
                    return null;

                default:
                    return evaluatorCore.Visit(theOperator);
            }
        }

        public object Visit(InOperator theOperator)
        {
            object left = Accept(theOperator.LeftOperand);

            foreach (CriteriaOperator op in theOperator.Operands)
            {
                if (Compare(left, Accept(op), true) == 0)
                {
                    return true;
                }
            }

            return false;
        }

        public object Visit(GroupOperator theOperator)
        {
            return evaluatorCore.Visit(theOperator);
        }

        public object Visit(OperandValue theOperand)
        {
            return evaluatorCore.Visit(theOperand);
        }

        public object Visit(FunctionOperator theOperator)
        {
            return evaluatorCore.Visit(theOperator);
        }

        public object Visit(AggregateOperand theOperand)
        {
            return evaluatorCore.Visit(theOperand);
        }

        public object Visit(OperandProperty theOperand)
        {
            return evaluatorCore.Visit(theOperand);
        }
    }
}