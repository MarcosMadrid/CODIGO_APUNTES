﻿using Azure;
using Azure.Data.Tables;

namespace MvcCoreSasStorage.Models
{
    public class Alumno : ITableEntity
    {
        public int _IdAlumno { get; set; }

        public int IdAlumno
        {
            get
            {
                return this._IdAlumno;
            }
            set
            {
                this._IdAlumno = value;
                this.RowKey = value.ToString();
            }
        }

        public string? Nombre { get; set; }

        private string? _Curso { get; set; }
        public string? Curso
        {
            get { return this._Curso; }
            set
            {
                this._Curso = value;
                this.PartitionKey = value!;
            }
        }

        public string? Apellido { get; set; }

        public int Nota { get; set; }

        public string? PartitionKey { get; set; }
        public string? RowKey { get; set; }
        public DateTimeOffset? Timestamp { get; set; }
        public ETag ETag { get; set; }
    }
}