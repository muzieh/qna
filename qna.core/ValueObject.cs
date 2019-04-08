﻿using System;
using System.Collections.Generic;
using System.Text;

namespace qna.core
{
	public abstract class ValueObject<T>
			where T : ValueObject<T>
	{
		//TODO: testing branching
		public override bool Equals(object obj)

		{
			var other = obj as T;
			if (ReferenceEquals(other, null))
				return false;

			return EqualsCore(other);
		}

		public override int GetHashCode()
		{
			return GetHashCodeCore();
		}

		public static bool operator ==(ValueObject<T> a, ValueObject<T> b)
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

		public static bool operator !=(ValueObject<T> a, ValueObject<T> b)
		{
			return !(a == b);
		}

		public abstract bool EqualsCore(T other);
		public abstract int GetHashCodeCore();
	}
}
