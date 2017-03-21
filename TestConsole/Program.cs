using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpLib;

namespace TestConsole
{
    class Program
    {
        private readonly bool _bValue;
        public Program()
        {
            _bValue = new Random().Next(10) % 2 == 0;
        }
        bool Bar()
        {
            return _bValue;
        }
        static void Main(string[] args)
        {
            CGWNetArray arr1 = new CGWNetArray();
            var ret = arr1.GetArrayType();
            arr1.Add(null);
            var ret2 = arr1.GetArrayType();
            arr1.Add(new Program());
            arr1.Add(new Program());
            arr1.Add(new Program());
            arr1.Add(new Program());
            arr1.Add(new Program());
            var arr2 = new CGWNetArray<Program>(arr1);
            var list1 = arr1.ToList();
            var list2 = arr2.ToList();

            var res1 = list2.Where(item => item.Bar());
        }
    }
}
