using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCS.BLL
{
    public class Respons<T>(T? data, string message, string? errors=null,bool sucesse=true)
    {
        public bool Success { get; set; }=sucesse;
        public string message { get; set; } = errors;
        public string? errors { get; set; }=message;
        public T? data { get; set; }=data;
    }
}
