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
    public class ModeloContable
    {
        #region Propiedades Públicas de Instancia

        /// <summary>
        /// Informe contable al que hace referencia: Balance, PyG o Estado de Cambios en el Patrimonio Neto
        /// </summary>
        public TipoModelo Modelo { get; }

        /// <summary>
        /// Modalidad del Informe Contable: Pymes, Normal o Abreviado
        /// </summary>
        public TipoModalidad Modalidad { get; }

        /// <summary>
        /// Conjunto de páginas que integran el Informe contable
        /// </summary>
        public List<Pagina> Paginas { get; set; } = new();

        /// <summary>
        /// Mapa con las cuentas contables y las casillas de los modelos contables del impuesto de sociedades
        /// </summary>
        public Mapa Mapa { get; set; }

        #endregion

        #region Constructor de Instancia

        /// <summary>
        /// Crea un nuevo modelo contable
        /// </summary>
        /// <param name="modelo">Tipo de modelo contable.</param>
        /// <param name="modalidad">Modalidad del modelo contable.</param>
        /// <param name="mapa">Mapa que define la estructura del modelo.</param>
        /// <param name="cuentasContables">Diccionario de cuentas contables con sus importes asociados.</param>
        public ModeloContable(TipoModelo modelo, TipoModalidad modalidad, Mapa mapa, Dictionary<string, decimal> CuentasContables)
        {
            Modelo = modelo;
            Modalidad = modalidad;
            Mapa = mapa;
            GenerarModelo(CuentasContables);
        }

        #endregion

        #region Indexador

        /// <summary>
        /// Devuelve la página por ID. Puede devolver null si no existe.
        /// </summary>
        public Pagina this[int id]
        {
            get
            {
                return Paginas.FirstOrDefault(p => p.ID == id) ?? throw new KeyNotFoundException($"No existe la página con ID {id}");
            }
        }

        #endregion

        #region Métodos
        /// <summary>
        /// Añade una página al modelo y la inserta manteniendo el orden por su identificador.
        /// </summary>
        /// <param name="pagina">Página que se desea añadir al modelo.</param>
        public void AñadirPagina(Pagina pagina)
        {
            Paginas.Add(pagina);
            Paginas = Paginas.OrderBy(p => p.ID).ToList();
        }

        /// <summary>
        /// Genera el modelo contable a partir de un conjunto de cuentas contables y sus valores.
        /// </summary>
        /// <param name="cuentasContables">Diccionario que contiene las cuentas contables como clave y sus importes asociados como valor.</param>
        public void GenerarModelo(Dictionary<string, decimal> cuentasContables)
        {
            Dictionary<string, (string Casilla, int Pagina)> datos = this.Mapa.GetDatos();

            foreach (var entrada in cuentasContables)
            {
                string? prefijo = null;

                (string Casilla, int Pagina) dato = default;

                if (entrada.Key.Length >= 5 && datos.TryGetValue(entrada.Key.Substring(0, 5), out dato))
                {
                    prefijo = entrada.Key.Substring(0, 5);
                }

                else if (entrada.Key.Length >= 4 && datos.TryGetValue(entrada.Key.Substring(0, 4), out  dato))
                {
                    prefijo = entrada.Key.Substring(0, 4);
                }

                else if (entrada.Key.Length >= 3 && datos.TryGetValue(entrada.Key.Substring(0, 3), out dato))
                {
                    prefijo = entrada.Key.Substring(0, 3);
                }

                else if (entrada.Key.Length >= 2 && datos.TryGetValue(entrada.Key.Substring(0, 2), out dato))
                {
                    prefijo = entrada.Key.Substring(0, 2);
                }

                if (prefijo == null)
                    return;

                var pagina = this[dato.Pagina];

                if (pagina == null)
                {
                    pagina = new Pagina(dato.Pagina);
                    AñadirPagina(pagina);
                }

                if (string.IsNullOrEmpty(dato.Casilla))
                    throw new InvalidOperationException("Casilla no puede ser nula o vacía");

                var casilla = pagina[dato.Casilla];

                if (casilla == null)
                {
                    pagina.Casillas.Add(new Casilla(dato.Casilla, entrada.Value));
                }
                else
                {
                    casilla.Valor += entrada.Value;
                }
            }
        }

        #endregion
    }
}