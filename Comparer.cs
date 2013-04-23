using System;
using System.Collections;
using System.Reflection;

namespace OrderingOperators
{
    public enum SortOrderEnum
    {
        Ascending,
        Descendin
    }
    public class GenericNumberComparer : IComparer
    {
        //Property of the Object that will be use to Order
        private String _Property = null;
        //It will be ordered by Ascending in default mode
        private SortOrderEnum _SortOrder = SortOrderEnum.Ascending;
        //GET/SET of the Property
        public String SortProperty
        {
            get { return _Property; }
            set { _Property = value; }
        }
        //GET/SEST of the SortOrder
        public SortOrderEnum SortOrder
        {
            get { return _SortOrder; }
            set { _SortOrder = value; }
        }


        public int Compare(object x, object y)
        {
            //Aqui pongo ObjectDumber, pero sirve para cualquier objeto y comparar 
            //aquellos que derivan de el objeto.

            ObjectDumper a;
            ObjectDumper b;

            if (x is float)
                a = (ObjectDumper)(x);
            else throw  new Exception("No object recognized");
            if (y is float)
                b = (ObjectDumper)(y);
            else throw new Exception("No object recognized");

            if (this.SortOrder.Equals(SortOrderEnum.Ascending))
                return a.CompareTo(b, this.SortProperty);
            else
                return b.CompareTo(a, this.SortProperty);

            }
        //Estudiar el metodo
        public int CompareTo(object obj, string Property)
        {
            try
            {
                //Coge el tipo de Objeto que invoca el metodo
                Type type = this.GetType();
                //Y en info, coge el tipo de propiedad con el nombre de Property
                PropertyInfo info = type.GetProperty(Property);

                Type type2 = obj.GetType();
                PropertyInfo info2 = type2.GetProperty(Property);

                object[] index = null;
                //Crea un objeto con el valor de la propiedad que se coge en info/info2
                object obj1 = info.GetValue(this, index);
                object obj2 = info2.GetValue(obj, index);
                //Hace Icomparable los objetos?
                IComparable Ic1 = (IComparable) obj1;
                IComparable Ic2 = (IComparable) obj2;
                //Compara los objetos y devuelve el numero diciendo quien es el mas alto.
                int returnValue = Ic1.CompareTo(Ic2);
                return returnValue;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

    }

}

