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

namespace ImpuestoSociedades.Src
{
    /// <summary>
    /// Representa la presentación del Impuesto sobre Sociedades.
    /// </summary>
    public abstract class Mod200
    {
        #region Propiedades Públicas de Instancia

        /// <summary>
        /// Ejercicio al que corresponde la presentación.
        /// </summary>
        public int Ejercicio { get; }

        /// <summary>
        /// Tipo de sociedad que realiza la presentación.
        /// </summary>
        public TipoEntidad TipoEntidad { get; }

        /// <summary>
        /// Conjunto de modelos contables que se van a generar.
        /// </summary>
        public List<ModeloContable> ModelosContables { get; } = new();

        /// <summary>
        /// Conjunto de mapas que agrupan cuentas contables y modelos contables
        /// </summary>
        public List<Mapa> Mapas { get; } = new ();

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="ejercicio">Ejercicio fiscal de la declaración.</param>
        /// <param name="tipoEntidad">Tipo de sociedad que presenta el impuesto.</param>
        public Mod200(int ejercicio, TipoEntidad tipoEntidad)
        {
            Ejercicio = ejercicio;
            TipoEntidad = tipoEntidad;
            AgregarMapas();
        }

        #endregion

        #region Métodos Abstractos

        /// <summary>
        /// Agrega la colección de mapas en función del ejercicio que se vaya a presentar
        /// </summary>
        public abstract void AgregarMapas();

        #endregion

        #region Métodos Publicos de Instancia

        /// <summary>
        /// Agrega un modelo contable a la presentación utilizando el tipo de modelo, modalidad y las entradas contables proporcionadas.
        /// </summary>
        /// <param name="modelo">Tipo de modelo contable a agregar.</param>
        /// <param name="modalidad">Modalidad del modelo contable.</param>
        /// <param name="entradasContables">Diccionario con las cuentas contables y sus importes asociados.</param>
        public void AgregarModeloContable(TipoModelo modelo, TipoModalidad modalidad,  Dictionary<string, decimal> entradasContables)
        {
            Mapa mapa = this.Mapas.FirstOrDefault(x =>x.TipoModelo == modelo && x.TipoModalidad == modalidad)  ?? throw new KeyNotFoundException("No se encontró el mapa solicitado"); ;

            ModelosContables.Add(new ModeloContable(modelo,modalidad,mapa, entradasContables));
        }

        /// <summary>
        /// Devuelve el fichero xml con la información contable
        /// </summary>
        public XmlElement GenerarPresentacion()
        {
            return Xml.CrearXml(this);
        }

        #endregion
    }
}

