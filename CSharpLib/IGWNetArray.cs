using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLib
{
    [Guid("3E3807DD-CFBC-4466-AF52-4F4EF716E6D6")]
    [ComVisible(true)]
    public interface IGWNetArray
    {
        void Clear();
        int GetSize();
        string GetArrayType();
        int Count { get; }
        void RemoveAt(int iIndex);
        void Add(object item);
        object GetAt(int iIndex);
    }

    [Guid("358AB20D-EA28-418E-91DB-620C0B63383D")]
    [ComVisible(true)]
    public class CGWNetArray : IGWNetArray
    {
        private readonly List<object> _array;
        public CGWNetArray()
        {
            _array = new List<object>();
        }

        public void Clear()
        {
            _array.Clear();
        }

        public int GetSize()
        {
            return _array.Count;
        }

        public int Count => _array.Count;

        public void RemoveAt(int iIndex)
        {
            _array.RemoveAt(iIndex);
        }

        public void Add(object item)
        {
            if (_array.Count > 0 && item != null && _array[0] != null)
            {
                string sUsedType = _array[0].GetType().ToString();
                string sItemType = item.GetType().ToString();
                if (sUsedType != sItemType)
                {
                    // Error
                    return;
                }
            }
            
            _array.Add(item);
        }

        public string GetArrayType()
        {
            if (_array.Count > 0)
            {
                return GetAt(0)?.GetType().ToString() ?? "";
            }
            return "";
        }

        public object GetAt(int iIndex)
        {
            return _array[iIndex];
        }

        [ComVisible(false)]
        public List<object> ToList()
        {
            return _array;
        }
    }
    
    public class CGWNetArray<T> : CGWNetArray where T : new()
    {
        private readonly List<T> _array;

        public CGWNetArray()
        {
            _array = new List<T>();
        }

        public CGWNetArray(CGWNetArray fromArray)
        {
            _array = new List<T>(fromArray.Count);
            for (int i = 0; i < fromArray.Count; i++)
            {
                var item = fromArray.GetAt(i);
                try
                {
                    _array.Add((T) item);
                }
                catch
                {
                    _array.Add(Activator.CreateInstance<T>());
                }
            }
        }
        
        public new int Count => _array.Count;
        
        public void Add(T item)
        {
            _array.Add(item);
        }
        
        public new T GetAt(int iIndex)
        {
            return _array[iIndex];
        }

        public new List<T> ToList()
        {
            return _array;
        }
    }
}
