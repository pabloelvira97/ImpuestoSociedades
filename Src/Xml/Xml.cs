/*
    This file is part of the DepositoDigital (R) project.
    Copyright (c) 2017-2018 Irene Solutions SL
    Authors: Irene Solutions SL.

    This program is free software; you can redistribute it and/or modify
    it under the terms of the GNU Affero General Public License version 3
    as published by the Free Software Foundation with the addition of the
    following permission added to Section 15 as permitted in Section 7(a):
    FOR ANY PART OF THE COVERED WORK IN WHICH THE COPYRIGHT IS OWNED BY
    IRENE SOLUTIONS SL. IRENE SOLUTIONS SL DISCLAIMS THE WARRANTY OF NON INFRINGEMENT
    OF THIRD PARTY RIGHTS
    
    This program is distributed in the hope that it will be useful, but
    WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY
    or FITNESS FOR A PARTICULAR PURPOSE.
    See the GNU Affero General Public License for more details.
    You should have received a copy of the GNU Affero General Public License
    along with this program; if not, see http://www.gnu.org/licenses or write to
    the Free Software Foundation, Inc., 51 Franklin Street, Fifth Floor,
    Boston, MA, 02110-1301 USA, or download the license from the following URL:
        http://www.irenesolutions.com/terms-of-use.pdf
    
    The interactive user interfaces in modified source and object code versions
    of this program must display Appropriate Legal Notices, as required under
    Section 5 of the GNU Affero General Public License.
    
    You can be released from the requirements of the license by purchasing
    a commercial license. Buying such a license is mandatory as soon as you
    develop commercial activities involving the DepositoDigital software without
    disclosing the source code of your own applications.
    These activities include: offering paid services to customers as an ASP,
    serving sii XML data on the fly in a web application, shipping DepositoDigital
    with a closed source product.
    
    For more information, please contact Irene Solutions SL. at this
    address: info@irenesolutions.com
 */

using System.Xml;
using System.Xml.Serialization;

namespace ImpuestoSociedades.Src
{
    /// <summary>
    /// Clase encargada de serializar un xml con la información contable.
    /// </summary>
    public class Xml
    {
        #region Métodos Estáticos

        /// <summary>
        /// Genera un elemento XML a partir de una instancia de <see cref="Mod200"/>.
        /// </summary>
        /// <param name="presentacion">Objeto que contiene la información necesaria para construir el XML.</param>
        /// <returns>Elemento XML que representa la presentación generada.</returns>
        public static XmlElement CrearXml(Mod200 presentacion)
        {
            XmlDocument doc = new XmlDocument();

            XmlElement Root = doc.CreateElement($"MOD200{presentacion.Ejercicio.ToString()}");
            doc.AppendChild(Root);

            XmlElement Modalidad = doc.CreateElement($"{presentacion.TipoEntidad.ToString()}");

            Root.AppendChild(Modalidad);

            foreach (ModeloContable Modelo in presentacion.ModelosContables)
            {

                XmlElement ModeloContable = doc.CreateElement($"{Modelo.Modelo.ToString()}");

                foreach (Pagina pagina in Modelo.Paginas)
                {
                    XmlElement Pagina = doc.CreateElement($"Pagina0{pagina.ID.ToString()}");

                    foreach(Casilla casilla in pagina.Casillas)
                    {
                        XmlElement Casilla = doc.CreateElement($"{casilla.Identificador}");
                        Casilla.InnerText = casilla.Valor.ToString();

                        Pagina.AppendChild( Casilla );
                    }

                    ModeloContable.AppendChild( Pagina );
                }

                Modalidad.AppendChild(ModeloContable);
            }

            return doc.DocumentElement ?? throw new InvalidOperationException();
        }

        #endregion
    }
}
