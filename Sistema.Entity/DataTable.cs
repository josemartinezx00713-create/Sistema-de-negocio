using System;
using System.Data;

namespace Sistema.Entity
{
    public class DataTable<T>
    {
        public int Count { get; set; }

        public static implicit operator DataTable<T>(DataTable v)
        {
            throw new NotImplementedException();
        }
    }
}