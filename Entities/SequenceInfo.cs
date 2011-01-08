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
using System.Collections.Generic;
using System.Text;
using Gremlin.FB2Librarian.Import.ObjectMetadata;

namespace Gremlin.FB2Librarian.Import.Entities
{
    [Table("SEQUENCES")]
    public class SequenceInfo : IEquatable<SequenceInfo>
    {
        private int? sequenceId;
        private string sequenceName;
        private int? sequenceNumber;

        [Column("SEQUENCEID")]
        public int? SequenceId
        {
            get
            {
                return this.sequenceId;
            }
            set
            {
                this.sequenceId = value;
            }
        }

        [Column("SEQUENCE")]
        public string SequenceName
        {
            get
            {
                return this.sequenceName;
            }
            set
            {
                this.sequenceName = value;
            }
        }

        public int? SequenceNumber
        {
            get
            {
                return this.sequenceNumber;
            }
            set
            {
                this.sequenceNumber = value;
            }
        }

        public override string ToString()
        {
            return this.sequenceName ?? base.ToString();
        }

        public bool Equals(SequenceInfo sequenceInfo)
        {
            if (sequenceInfo == null)
            {
                return false;
            }

            return Equals(sequenceId, sequenceInfo.sequenceId) && Equals(sequenceName, sequenceInfo.sequenceName);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            return Equals(obj as SequenceInfo);
        }

        public override int GetHashCode()
        {
            return sequenceId.GetHashCode() + 29 * (sequenceName != null ? sequenceName.GetHashCode() : 0);
        }
    }
}
