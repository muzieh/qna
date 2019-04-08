using System;
using System.Collections.Generic;
using System.Text;

namespace qna.core
{
	public abstract class Entity
	{
		public Entity() : this(null)
		{
			Console.WriteLine("inside Enity constructor");
		}

		public Entity(string id)
		{
			this.Id = id;
			Console.WriteLine("inside parameter contructor");
		}
		//TODO: shouldn't be private set? would break test
		public string Id { get; private set; }

		public override bool Equals(object obj)
		{
			var other = obj as Entity;
			if (other == null)
			{
				return false;
			}
			if (ReferenceEquals(this, other))
			{
				return true;
			}

			if (GetType() != other.GetType())
			{
				return false;
			}

			if (this.Id == String.Empty || other.Id == String.Empty)
			{
				return false;
			}

			return this.Id == other.Id;
		}

		public static bool operator ==(Entity a, Entity b)
		{
			if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
			{
				return true;
			}

			if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
			{
				return false;
			}


			return a.Equals(b);
		}

		public static bool operator !=(Entity a, Entity b)
		{
			return !(a == b);
		}

		public override int GetHashCode()
		{
			return (GetType().ToString() + Id.ToString()).GetHashCode();
		}
	}
}
