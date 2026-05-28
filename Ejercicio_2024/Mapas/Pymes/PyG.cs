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

namespace ImpuestoSociedades.Ejercicio_2024.Mapas.Pymes
{
    /// <summary>
    /// Mapa cuentas contables con las casillas del impuesto de sociedades para la Cuenta de Pérdidas y Ganancias del Ejercicio 2024.
    /// </summary>
    public class PyG : Mapa
    {
        #region Constructor
        public PyG() : base(TipoModelo.CuentaPyG, TipoModalidad.Pymes, datos)
        {

        }

        #endregion

        #region Variables Privadas de Instancia

        private static readonly Dictionary<string, (string Casilla, int Pagina)> datos = new()
        {
            { "700",  ("T00255", 7) },
            { "701",  ("T00255", 7) },
            { "702",  ("T00255", 7) },
            { "703",  ("T00255", 7) },
            { "704",  ("T00255", 7) },
            { "705",  ("T00255", 7) },
            { "706",  ("T00255", 7) },
            { "708",  ("T00255", 7) },
            { "709",  ("T00255", 7) },
            { "71",   ("T00258", 7) },
            { "6930", ("T00258", 7) },
            { "7930", ("T00258", 7) },
            { "73",   ("T00259", 7) },
            { "600",  ("T00760", 7) },
            { "606",  ("T00760", 7) },
            { "608",  ("T00760", 7) },
            { "609",  ("T00760", 7) },
            { "610",  ("T00761", 7) },
            { "601",  ("T00762", 7) },
            { "602",  ("T00762", 7) },
            { "611",  ("T00763", 7) },
            { "612",  ("T00763", 7) },
            { "607",  ("T00263", 7) },
            { "6931", ("T00264", 7) },
            { "6932", ("T00264", 7) },
            { "6933", ("T00264", 7) },
            { "7931", ("T00264", 7) },
            { "7932", ("T00264", 7) },
            { "7933", ("T00264", 7) },
            { "752",  ("T00267", 7) },
            { "740",  ("T00269", 7) },
            { "747",  ("T00269", 7) },
            { "640",  ("T00271", 7) },
            { "641",  ("T00273", 7) },
            { "642",  ("T00274", 7) },
            { "643",  ("T00275", 7) },
            { "6450", ("T00276", 7) },
            { "649",  ("T00277", 7) },
            { "644",  ("T00278", 7) },
            { "6457", ("T00278", 7) },
            { "7950", ("T00278", 7) },
            { "7957", ("T00278", 7) },
            { "623",  ("T00253", 7) },
            { "620",  ("T002544", 7) },
            { "621",  ("T002544", 7) },
            { "622",  ("T002544", 7) },
            { "624",  ("T002544", 7) },
            { "625",  ("T002544", 7) },
            { "626",  ("T002544", 7) },
            { "627",  ("T002544", 7) },
            { "628",  ("T002544", 7) },
            { "629",  ("T002544", 7) },
            { "631",  ("T00281", 7) },
            { "634",  ("T00281", 7) },
            { "636",  ("T00281", 7) },
            { "639",  ("T00281", 7) },
            { "650",  ("T00282", 7) },
            { "694",  ("T00282", 7) },
            { "695",  ("T00282", 7) },
            { "794",  ("T00282", 7) },
            { "7954", ("T00282", 7) },
            { "651",  ("T00283", 7) },
            { "659",  ("T00283", 7) },
            { "68",   ("T00284", 7) },
            { "746",  ("T00285", 7) },
            { "7951", ("T00286", 7) },
            { "7952", ("T00286", 7) },
            { "7955", ("T00286", 7) },
            { "7956", ("T00286", 7) },
            { "690",  ("T00289", 7) },
            { "691",  ("T00289", 7) },
            { "692",  ("T00289", 7) },
            { "790",  ("T00290", 7) },
            { "791",  ("T00290", 7) },
            { "792",  ("T00290", 7) },
            { "770",  ("T00292", 7) },
            { "771",  ("T00292", 7) },
            { "772",  ("T00292", 7) },
            { "670",  ("T00293", 7) },
            { "671",  ("T00293", 7) },
            { "672",  ("T00293", 7) },
            { "678",  ("T00295", 7) },
            { "778",  ("T00295", 7) },
            { "7600", ("T00299", 8) },
            { "7601", ("T00299", 8) },
            { "7602", ("T00300", 8) },
            { "7603", ("T00300", 8) },
            { "7610", ("T00302", 8) },
            { "7611", ("T00302", 8) },
            { "76200",("T00302", 8) },
            { "76201",("T00302", 8) },
            { "76210",("T00302", 8) },
            { "76211",("T00302", 8) },
            { "7612", ("T00303", 8) },
            { "7613", ("T00303", 8) },
            { "76202",("T00303", 8) },
            { "76203",("T00303", 8) },
            { "76212",("T00303", 8) },
            { "76213",("T00303", 8) },
            { "767",  ("T00303", 8) },
            { "769",  ("T00303", 8) },
            { "746",  ("T00304", 8) },
            { "6610", ("T00306", 8) },
            { "6611", ("T00306", 8) },
            { "6615", ("T00306", 8) },
            { "6616", ("T00306", 8) },
            { "6620", ("T00306", 8) },
            { "6621", ("T00306", 8) },
            { "6640", ("T00306", 8) },
            { "6641", ("T00306", 8) },
            { "6650", ("T00306", 8) },
            { "6651", ("T00306", 8) },
            { "6654", ("T00306", 8) },
            { "6655", ("T00306", 8) },
            { "6612", ("T00307", 8) },
            { "6613", ("T00307", 8) },
            { "6617", ("T00307", 8) },
            { "6618", ("T00307", 8) },
            { "6622", ("T00307", 8) },
            { "6623", ("T00307", 8) },
            { "6624", ("T00307", 8) },
            { "6642", ("T00307", 8) },
            { "6643", ("T00307", 8) },
            { "6652", ("T00307", 8) },
            { "6653", ("T00307", 8) },
            { "6656", ("T00307", 8) },
            { "6657", ("T00307", 8) },
            { "669",  ("T00307", 8) },
            { "660",  ("T00308", 8) },
            { "663",  ("T00309", 8) },
            { "763",  ("T00309", 8) },
            { "668",  ("T00312", 8) },
            { "768",  ("T00312", 8) },
            { "666",  ("T00315", 8) },
            { "667",  ("T00315", 8) },
            { "673",  ("T00315", 8) },
            { "675",  ("T00315", 8) },
            { "766",  ("T00318", 8) },
            { "773",  ("T00318", 8) },
            { "775",  ("T00318", 8) },
            { "6300", ("T00326", 8) },
            { "6301", ("T00326", 8) },
            { "633",  ("T00326", 8) },
            { "638",  ("T00326", 8) }
        };

        #endregion
    }
}
