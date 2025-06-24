using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapacitacionCertificacion.Models
{
    public class RecordatorioAutomatico
    {
        private static readonly Lazy<RecordatorioAutomatico> _instancia =
            new Lazy<RecordatorioAutomatico>(() => new RecordatorioAutomatico());

        private readonly List<String> _recordatoriosPendientes = new List<String>();

        private DateTime ultimaEjecucion = DateTime.MinValue;

        public static RecordatorioAutomatico getInstancia => _instancia.Value;

        private RecordatorioAutomatico() { 
        }

        public Boolean isTimeParaEjecucion()
        {
            TimeSpan intervalo = TimeSpan.FromSeconds(20);

            if (DateTime.Now - ultimaEjecucion >= intervalo)
            {
                ultimaEjecucion = DateTime.Now;
                return true;
            }

            return false;
        }

        public void agregarRecordatorio(String recordatorio)
        {
            if (recordatorio != null)
            {
                _recordatoriosPendientes.Add(recordatorio);
            }
        }

        public void removerRecordatorio(String recordatorio)
        {
            if (_recordatoriosPendientes.Contains(recordatorio))
            {
                _recordatoriosPendientes.Remove(recordatorio);
            }
        }

        public String imprimirRecordatorios()
        {
            if (_recordatoriosPendientes.Count == 1)
            {
                return _recordatoriosPendientes.First();
            }else if (_recordatoriosPendientes.Count > 1)
            {
                return "Tienes " + _recordatoriosPendientes.Count + " pendientes";
            }

            return "";
        }
    }
}
