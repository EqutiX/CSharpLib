using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLib
{
    [Guid("3E3807DD-CFBC-4466-AF52-4F4EF716E6D5")]
    [ComVisible(true)]
    public interface IGWStringNetArray
    {
        void Clear();
        int GetSize();
        string GetArrayType();
        int Count { get; }
        void RemoveAt(int iIndex);
        void Add(string item);
        
    }

    public abstract class CGWBaseNetArray
    {
        
    }

    [Guid("358AB20D-EA28-418E-91DB-620C0B63383C")]
    [ComVisible(true)]
    public class CGWStringNetArray : CGWBaseNetArray, IGWStringNetArray
    {
        private List<string> _array;
        private string _sType;
        public CGWStringNetArray()
        {
            _array = new List<string>();
            _sType = typeof(string).ToString();
        }

        public void Clear()
        {
            List<object> arr = new List<object>();
            arr.Add(1);
            var type = arr[0].GetType();
            //arr.Where(item => item > 3);
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

        public void Add(string item)
        {
            _array.Add(item);
        }

        public string GetArrayType()
        {
            return _sType;
        }

        public void Test((int, int) input)
        {
            
        }
    }
}
