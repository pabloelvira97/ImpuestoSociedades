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
using ImpuestoSociedades.Src;

namespace ImpuestoSociedades.Src
{
    /// <summary>
    /// Relación existente ente las cuentas del Plan General Contable y las casillas de los diferentes modelos contables del modelo 200.
    /// </summary>
    public abstract class Mapa
    {
        #region Propiedades Públicas de Instancia

        /// <summary>
        /// Modalidad del Informe Contable: Pymes, Normal o Abreviado
        /// </summary>
        public TipoModelo TipoModelo { get; }

        /// <summary>
        /// Modalidad del Informe Contable: Pymes, Normal o Abreviado
        /// </summary>
        public TipoModalidad TipoModalidad { get; }

        /// <summary>
        /// Diccionario que contiene la relación entre cada cuenta del PGC 
        /// y la casilla y página del modelo contable del impuesto de sociedades.
        /// </summary>
        public Dictionary<string, (string Casilla, int Pagina)> Datos { get;}

        #endregion

        #region Constructor

        /// <summary>
        /// Crea un nuevo mapa
        /// </summary>
        /// <param name="modelo">Especifica el tipo de modelo del mapa.</param>
        /// <param name="modalidad">Indica la modalidad asociada al mapa.</param>
        /// <param name="datos">Colección de datos que mapea claves a una casilla y número de página.</param>
        public Mapa(TipoModelo modelo, TipoModalidad modalidad, Dictionary<string, (string Casilla, int Pagina)> datos)
        {
            TipoModelo = modelo;
            TipoModalidad = modalidad;
            Datos = datos;
        }

        public Dictionary<string, (string Casilla, int Pagina)> GetDatos()
        {
            return this.Datos;
        }

        #endregion
    }
}
