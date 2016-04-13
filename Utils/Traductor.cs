using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;

namespace Ine.SihPublico.UI.Web.Utils
{
    public static class Traductor
    {
        public static DataTable ToDataTable<T>(this IEnumerable<T> elementos)
        {
            DataTable tablaResultado = new DataTable(typeof(T).Name);
            PropertyInfo[] propiedades = typeof(T).GetProperties();

            tablaResultado = ColumnasPropiedades(propiedades);
            foreach (var elemento in elementos)
            {
                Int32 numeroPropiedades = propiedades.Any(x => x.PropertyType == typeof(ExtensionDataObject)) ? propiedades.Length - 1 : propiedades.Length;
                var valores = new object[numeroPropiedades];
                Int32 indice = 0;

                foreach (var propiedad in propiedades)
                {
                    if (propiedad.PropertyType == typeof(ExtensionDataObject)) continue;
                    valores[indice] = propiedad.GetValue(elemento, null);
                    indice++;
                }

                tablaResultado.Rows.Add(valores);
            }
            return tablaResultado;
        }

        public static DataTable ColumnasPropiedades(PropertyInfo[] propiedades)
        {
            DataTable tablaResultado = new DataTable();
            foreach (var prop in propiedades)
            {
                if (prop.PropertyType == typeof(ExtensionDataObject)) continue;
                Type tipoDatoPropiedad = prop.PropertyType;
                if (tipoDatoPropiedad.IsGenericType && tipoDatoPropiedad.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
                    tipoDatoPropiedad = new NullableConverter(tipoDatoPropiedad).UnderlyingType;

                tablaResultado.Columns.Add(prop.Name, tipoDatoPropiedad);
            }
            return tablaResultado;
        }
    }
}