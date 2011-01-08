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
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reflection;
using System.Xml.Serialization;

namespace Gremlin.FB2Librarian.Import
{
    internal enum LegendViewMode
    {
        None,
        BookInfo,
        ConflictInfo,
        ErrorInfo
    }

    [XmlRoot("LegendItem")]
    public class XmlLegendItem
    {
        private ImportStatus status;
        private int counter;

        public XmlLegendItem()
        {
        }

        internal XmlLegendItem(ProcessLegendItem legendItem)
        {
            if (legendItem == null)
            {
                throw new ArgumentNullException("legendItem");
            }

            status = legendItem.Status;
            counter = legendItem.Counter;
        }

        [XmlAttribute]
        public ImportStatus Status
        {
            get
            {
                return this.status;
            }
            set
            {
                this.status = value;
            }
        }

        [XmlText]
        public int Counter
        {
            get
            {
                return this.counter;
            }
            set
            {
                this.counter = value;
            }
        }
    }

    [Obfuscation(Feature = "renaming", ApplyToMembers = false, Exclude = true, StripAfterObfuscation = true)]
    internal class ProcessLegendItem : INotifyPropertyChanged
    {
        private readonly ImportStatus status;
        private readonly string description;
        private int counter;

        public event PropertyChangedEventHandler PropertyChanged;

        public ProcessLegendItem(ImportStatus status, string description)
        {
            this.status = status;
            this.description = description;
            this.counter = 0;
        }

        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        [Obfuscation(Feature = "renaming", Exclude = true, StripAfterObfuscation = true)]
        public ImportStatus Status
        {
            get
            {
                return this.status;
            }
        }

        [Obfuscation(Feature = "renaming", Exclude = true, StripAfterObfuscation = true)]
        public string Description
        {
            get
            {
                return this.description;
            }
        }

        [Obfuscation(Feature = "renaming", Exclude = true, StripAfterObfuscation = true)]
        public int Counter
        {
            get
            {
                return this.counter;
            }

            set
            {
                if (this.counter != value)
                {
                    this.counter = value;
                    NotifyPropertyChanged("Counter");
                }
            }
        }
    }

    internal class ProcessLegendItemCollection : KeyedCollection<ImportStatus, ProcessLegendItem>
    {
        public ProcessLegendItemCollection() : base()
        {
        }

        protected override ImportStatus GetKeyForItem(ProcessLegendItem item)
        {
            return item.Status;
        }

        public void ResetCounters()
        {
            foreach (ProcessLegendItem item in this)
            {
                item.Counter = 0;
            }
        }

        public void IncrementCounter(ImportStatus counter)
        {
            if (this.Contains(counter))
            {
                this[counter].Counter++;
            }
        }

        public void DecrementCounter(ImportStatus counter)
        {
            if (this.Contains(counter))
            {
                this[counter].Counter--;
            }
        }

        public void SetCounterValue(ImportStatus counter, int value)
        {
            if (this.Contains(counter))
            {
                this[counter].Counter = value;
            }
        }
    }
}