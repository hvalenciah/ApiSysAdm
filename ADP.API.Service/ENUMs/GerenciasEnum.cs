namespace ADP.API.Service.Enums.Balcan
{
    public static class GerenciasEnum
    {
        private static readonly Dictionary<int, string> Gerencias = new()
        {
            { 110, "GERENCIA DE MEDICION DE LA GESTION" },
            { 120, "GERENCIA SEGUIMIENTO PLAN DE INVERSION" },
            { 1150, "GERENCIA DE CALIDAD Y PROCESOS" },
            { 1300, "GERENCIA DE COMUNICACION E IMAGEN" },
            { 1600, "GERENCIA VINCULACION SOCIAL Y DEF USUA" },
            { 1930, "GERENCIA DE SEGURIDAD E HIGIENE" },
            { 1940, "GERENCIA DE CONTRATOS Y LICITACIONES" },
            { 2100, "GERENCIA DE PROYECTOS DE AGUA Y DRENAJE" },
            { 2102, "GERENCIA FACTIBILIDADES" },
            { 2200, "GERENCIA DE SECTORIZACION" },
            { 2500, "GERENCIA DE PROYECTOS AUTOM E HIDROMETRI" },
            { 3150, "GERENCIA PASEO DEL RIO" },
            { 3400, "GERENCIA DE POTABILIZACION" },
            { 3800, "GERENCIA DE DISTRIBUCION" },
            { 3900, "GERENCIA DETECCION Y REPARACION FUGAS" },
            { 4120, "GERENCIA ANALISIS Y PREVISION DE DATOS" },
            { 4200, "GERENCIA DE ATENCION A CLIENTES" },
            { 4400, "GERENCIA DE ATENCION CIUDADANA" },
            { 4500, "GERENCIA ESCUADRON ACUA" },
            { 4700, "GERENCIA DE CUENTAS ESPECIALES" },
            { 4800, "GERENCIA DE EFICIENCIA COMERCIAL" },
            { 4900, "GERENCIA DE COBRANZA" },
            { 5100, "GERENCIA DE ADMINISTRACION Y RRHH" },
            { 5200, "GERENCIA DE CONTABILIDAD" },
            { 5300, "GERENCIA REC MATERIALES SERV GENERALES" },
            { 5400, "GERENCIA DE RECAUDACION" },
            { 5500, "GERENCIA DE ADQUISICIONES" },
            { 5600, "GERENCIA CONTRALORIA ADMINISTRATIVA" },
            { 5700, "GERENCIA CONTRALORIA OBRAS PLANEACION M" },
            { 7200, "GERENCIA LINEAS DE CONDUCCION Y POZOS" },
            { 7600, "GERENCIA MANTENIMIENTO Y ENERGIA" },
            { 8100, "GERENCIA DE SANEAMIENTO" },
            { 8200, "GERENCIA DE DRENAJE Y ALCANTARILLADO" },
            { 9100, "GERENCIA TECNOLOGIAS DE LA INFORMACION" }
        };

        public static string GetNombreGerencia(int? codigo)
        {
            if (!codigo.HasValue) return string.Empty;
            return Gerencias.TryGetValue(codigo.Value, out var nombre) ? nombre : $"GERENCIA {codigo.Value}";
        }
    }
}