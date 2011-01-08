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
using System.Xml;

namespace Gremlin.FB2Librarian.Import.ObjectModel
{
	public class AuthorInfoNode : DocumentNode, IEquatable<AuthorInfoNode>, IAuthorInfoNode
	{
		private string firstName;
		private string middleName;
		private string lastName;
		private string nickName;
		private List<string> homepage;
		private List<string> email;
		private string id;

        public AuthorInfoNode(string id, string firstName, string middleName, string lastName, string nickName) : this()
	    {
            this.id = id;
            this.firstName = firstName;
	        this.middleName = middleName;
	        this.lastName = lastName;
	        this.nickName = nickName;
	    }

	    public AuthorInfoNode(string firstName, string middleName, string lastName) : this(null, firstName, middleName, lastName)
	    {
	    }

	    public AuthorInfoNode(string id, string firstName, string middleName, string lastName) : this(id, firstName, middleName, lastName, null)
	    {
	    }

	    public AuthorInfoNode()
		{
            this.homepage = new List<string>();
            this.email = new List<string>();
		}
		
		public string FirstName 
		{
			get 
			{ 
				return firstName; 
			}
			set 
			{ 
				firstName = value; 
			}
		}
		
		public string MiddleName 
		{
			get 
			{ 
				return middleName; 
			}
			set 
			{ 
				middleName = value; 
			}
		}
		
		public string LastName 
		{
			get 
			{ 
				return lastName; 
			}
			set 
			{ 
				lastName = value; 
			}
		}
		
		public string NickName 
		{
			get 
			{ 
				return nickName; 
			}
			set 
			{ 
				nickName = value; 
			}
		}
		
		public string Id 
		{
			get 
			{ 
				return id; 
			}
			set 
			{ 
				id = value; 
			}
		}

	    public IList<string> Homepage
	    {
	        get
	        {
	            return this.homepage;
	        }
	    }

	    public IList<string> Email
	    {
	        get
	        {
	            return this.email;
	        }
	    }
        public string DisplayName
        {
            get
            {
                if (!String.IsNullOrEmpty(this.firstName) && !String.IsNullOrEmpty(this.lastName))
                {
                    return String.Format("{0}, {1} {2}", this.lastName, this.firstName, this.middleName).Trim();
                }
                
                if (String.IsNullOrEmpty(this.firstName) && !String.IsNullOrEmpty(this.lastName))
                {
                    return this.lastName.Trim();
                }
                
                if (!String.IsNullOrEmpty(this.firstName) && String.IsNullOrEmpty(this.lastName))
                {
                    return String.Format("{0} {1}", this.firstName, this.middleName).Trim();
                }
                
                if (String.IsNullOrEmpty(this.firstName) && String.IsNullOrEmpty(this.lastName) && !String.IsNullOrEmpty(this.middleName))
                {
                    return this.middleName.Trim();
                }
                
                if (String.IsNullOrEmpty(this.firstName) && String.IsNullOrEmpty(this.lastName) && !String.IsNullOrEmpty(this.nickName))
                {
                    return this.nickName.Trim();
                }
                
                return "-";
            }
        }

	    public override void Load(XmlElement parentNode)
		{
			if(parentNode == null)
			{
				throw new ArgumentNullException("parentNode");
			}
			
			this.firstName = LoadRequiredElement(parentNode, "./fb:first-name");
            this.middleName = LoadElement(parentNode, "./fb:middle-name");
            this.lastName = LoadRequiredElement(parentNode, "./fb:last-name");
            this.nickName = LoadRequiredElement(parentNode, "./fb:nickname");
            this.id = LoadElement(parentNode, "./fb:id");
            this.homepage = LoadElementsList(parentNode, "./fb:home-page");
            this.email = LoadElementsList(parentNode, "./fb:email");
		}

	    public override XmlElement Store(XmlDocument document, XmlElement element)
	    {
	        XmlElement childElement;

	        if (document == null)
	        {
	            throw new ArgumentNullException("document");
	        }
	        
            if (element == null)
	        {
	            throw new ArgumentNullException("element");
	        }

            if((childElement = StoreRequiredElement(document, "first-name", this.firstName)) != null)
	        {
	            element.AppendChild(childElement);
	        }

            if ((childElement = StoreElement(document, "middle-name", this.middleName)) != null)
            {
                element.AppendChild(childElement);
            }

            if ((childElement = StoreRequiredElement(document, "last-name", this.lastName)) != null)
            {
                element.AppendChild(childElement);
            }

            if ((childElement = StoreRequiredElement(document, "nickname", this.nickName)) != null)
            {
                element.AppendChild(childElement);
            }

            if ((childElement = StoreElement(document, "id", this.id)) != null)
            {
                element.AppendChild(childElement);
            }

	        foreach (string value in this.homepage)
	        {
                if ((childElement = StoreElement(document, "home-page", value)) != null)
                {
                    element.AppendChild(childElement);
                }
            }

            foreach (string value in this.email)
            {
                if ((childElement = StoreElement(document, "email", value)) != null)
                {
                    element.AppendChild(childElement);
                }
            }

            if(element.ChildNodes.Count == 0)
            {
                return null;
            }

	        return element;
	    }

	    public override bool IsEmpty()
	    {
	        return false;
	    }


	    public bool Equals(AuthorInfoNode authorInfoNode)
	    {
	        if (authorInfoNode == null)
	        {
	            return false;
	        }
	        if (!Equals(firstName, authorInfoNode.firstName))
	        {
	            return false;
	        }
	        if (!Equals(middleName, authorInfoNode.middleName))
	        {
	            return false;
	        }
	        if (!Equals(lastName, authorInfoNode.lastName))
	        {
	            return false;
	        }
	        if (!Equals(nickName, authorInfoNode.nickName))
	        {
	            return false;
	        }
	        if (!Equals(id, authorInfoNode.id))
	        {
	            return false;
	        }

	        return true;
	    }

	    public override bool Equals(object obj)
	    {
	        if (ReferenceEquals(this, obj))
	        {
	            return true;
	        }
	        
            return Equals(obj as AuthorInfoNode);
	    }

	    public override int GetHashCode()
	    {
	        int result = firstName != null ? firstName.GetHashCode() : 0;
	        
            result = 29 * result + (middleName != null ? middleName.GetHashCode() : 0);
	        result = 29 * result + (lastName != null ? lastName.GetHashCode() : 0);
	        result = 29 * result + (nickName != null ? nickName.GetHashCode() : 0);
	        result = 29 * result + (id != null ? id.GetHashCode() : 0);
	        
            return result;
	    }
	}
}
