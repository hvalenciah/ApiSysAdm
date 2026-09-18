namespace ADP.API.Service.Enums.Balcan
{
    public static class DireccionesEnum
    {
        private static readonly Dictionary<int, string> Direcciones = new()
        {
            { 100, "DIRECCION ESTRATEG DE NEG Y ASUNT CORP" },
            { 1000, "DIRECCION GENERAL" },
            { 2000, "DIRECCION PLANEACION" },
            { 3000, "DIRECCION DE OPERACION DE DISTRIBUCION" },
            { 4000, "DIRECCION COMERCIAL" },
            { 5000, "DIRECCION DE ADMINISTRACION Y FINANZAS" },
            { 6000, "DIRECCION JURIDICA" },
            { 7000, "DIRECCION DE PRODUCCION Y MANTTO" },
            { 8000, "DIRECCION DE DRENAJE Y SANEAMIENTO" },
            { 9000, "DIRECCION TRANSFORMACION DIGITAL" }
        };

        public static string GetNombreDireccion(int? codigo)
        {
            if (!codigo.HasValue) return string.Empty;
            return Direcciones.TryGetValue(codigo.Value, out var nombre) ? nombre : $"DIRECCIÓN {codigo.Value}";
        }
    }
}