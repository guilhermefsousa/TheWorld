using System;
using System.Collections.Generic;
using TheWorld.Models.Repositorio.Interfaces;

namespace TheWorld.Models.Contexto
{
    public class MundoContextSeedData
    {
        private readonly IViagemRepositorio _viagemRepositorio;
        private readonly IParadaRepositorio _paradaRepositorio;

        public MundoContextSeedData(IViagemRepositorio viagemRepositorio, IParadaRepositorio paradaRepositorio)
        {
            _viagemRepositorio = viagemRepositorio;
            _paradaRepositorio = paradaRepositorio;
        }

        public void EnsureSeedData()
        {
            if (_viagemRepositorio.ExisteAlgumaViagem())
                return;

            //Adicionando nova viagem
            var viagemSp = new Viagem
            {
                Nome = "Viagem a São Paulo",
                Criada = DateTime.UtcNow,
                NomeUsuario = "",
                Paradas = new List<Parada>
                {
                    new Parada { Nome = "Batatais, SP", Chegada = new DateTime(2016, 03, 02), Latitude = 33.74888, Longitude = -84.38700, Ordem = 0 },
                    new Parada { Nome = "Ribeirão Preto, SP", Chegada = new DateTime(2016, 03, 02), Latitude = 33.74888, Longitude = -84.38700, Ordem = 1 },
                    new Parada { Nome = "pirassununga, SP", Chegada = new DateTime(2016, 03, 02), Latitude = 33.74888, Longitude = -84.38700, Ordem = 2 },
                    new Parada { Nome = "São Paulo, SP", Chegada = new DateTime(2016, 03, 02), Latitude = 33.74888, Longitude = -84.38700, Ordem = 3 }
                }
            };

            _viagemRepositorio.PostViagem(viagemSp);
            _paradaRepositorio.PostListaParadas(viagemSp.Paradas);

            var viagemAoMundo = new Viagem
            {
                Nome = "Viagem ao Mundo",
                Criada = new DateTime(2015,08,10),
                NomeUsuario = "",
                Paradas = new List<Parada>
                {
                    new Parada { Ordem = 0, Latitude =  33.748995, Longitude =  -84.387982, Nome = "Atlanta, Georgia", Chegada = DateTime.Parse("Jun 3, 2014") },
                    new Parada { Ordem = 1, Latitude =  48.856614, Longitude =  2.352222, Nome = "Paris, France", Chegada = DateTime.Parse("Jun 4, 2014") },
                    new Parada { Ordem = 2, Latitude =  50.850000, Longitude =  4.350000, Nome = "Brussels, Belgium", Chegada = DateTime.Parse("Jun 25, 2014") },
                    new Parada { Ordem = 3, Latitude =  51.209348, Longitude =  3.224700, Nome = "Bruges, Belgium", Chegada = DateTime.Parse("Jun 28, 2014") },
                    new Parada { Ordem = 4, Latitude =  48.856614, Longitude =  2.352222, Nome = "Paris, France", Chegada = DateTime.Parse("Jun 30, 2014") },
                    new Parada { Ordem = 5, Latitude =  51.508515, Longitude =  -0.125487, Nome = "London, UK", Chegada = DateTime.Parse("Jul 8, 2014") },
                    new Parada { Ordem = 6, Latitude =  51.454513, Longitude =  -2.587910, Nome = "Bristol, UK", Chegada = DateTime.Parse("Jul 24, 2014") },
                    new Parada { Ordem = 7, Latitude =  52.078000, Longitude =  -2.783000, Nome = "Stretton Sugwas, UK", Chegada = DateTime.Parse("Jul 29, 2014") },
                    new Parada { Ordem = 8, Latitude =  51.864211, Longitude =  -2.238034, Nome = "Gloucestershire, UK", Chegada = DateTime.Parse("Jul 30, 2014") },
                    new Parada { Ordem = 9, Latitude =  52.954783, Longitude =  -1.158109, Nome = "Nottingham, UK", Chegada = DateTime.Parse("Jul 31, 2014") },
                    new Parada { Ordem = 10, Latitude =  51.508515, Longitude =  -0.125487, Nome = "London, UK", Chegada = DateTime.Parse("Aug 1, 2014") },
                    new Parada { Ordem = 11, Latitude =  55.953252, Longitude =  -3.188267, Nome = "Edinburgh, UK", Chegada = DateTime.Parse("Aug 5, 2014") },
                    new Parada { Ordem = 12, Latitude =  55.864237, Longitude =  -4.251806, Nome = "Glasgow, UK", Chegada = DateTime.Parse("Aug 6, 2014") },
                    new Parada { Ordem = 13, Latitude =  57.149717, Longitude =  -2.094278, Nome = "Aberdeen, UK", Chegada = DateTime.Parse("Aug 7, 2014") },
                    new Parada { Ordem = 14, Latitude =  55.953252, Longitude =  -3.188267, Nome = "Edinburgh, UK", Chegada = DateTime.Parse("Aug 8, 2014") },
                    new Parada { Ordem = 15, Latitude =  51.508515, Longitude =  -0.125487, Nome = "London, UK", Chegada = DateTime.Parse("Aug 10, 2014") },
                    new Parada { Ordem = 16, Latitude =  52.370216, Longitude =  4.895168, Nome = "Amsterdam, Netherlands", Chegada = DateTime.Parse("Aug 14, 2014") },
                    new Parada { Ordem = 17, Latitude =  48.583148, Longitude =  7.747882, Nome = "Strasbourg, France", Chegada = DateTime.Parse("Aug 17, 2014") },
                    new Parada { Ordem = 18, Latitude =  46.519962, Longitude =  6.633597, Nome = "Lausanne, Switzerland", Chegada = DateTime.Parse("Aug 19, 2014") },
                    new Parada { Ordem = 19, Latitude =  46.021073, Longitude =  7.747937, Nome = "Zermatt, Switzerland", Chegada = DateTime.Parse("Aug 27, 2014") },
                    new Parada { Ordem = 20, Latitude =  46.519962, Longitude =  6.633597, Nome = "Lausanne, Switzerland", Chegada = DateTime.Parse("Aug 29, 2014") },
                    new Parada { Ordem = 21, Latitude =  53.349805, Longitude =  -6.260310, Nome = "Dublin, Ireland", Chegada = DateTime.Parse("Sep 2, 2014") },
                    new Parada { Ordem = 22, Latitude =  54.597285, Longitude =  -5.930120, Nome = "Belfast, Northern Ireland", Chegada = DateTime.Parse("Sep 7, 2014") },
                    new Parada { Ordem = 23, Latitude =  53.349805, Longitude =  -6.260310, Nome = "Dublin, Ireland", Chegada = DateTime.Parse("Sep 9, 2014") },
                    new Parada { Ordem = 24, Latitude =  47.368650, Longitude =  8.539183, Nome = "Zurich, Switzerland", Chegada = DateTime.Parse("Sep 16, 2014") },
                    new Parada { Ordem = 25, Latitude =  48.135125, Longitude =  11.581981, Nome = "Munich, Germany", Chegada = DateTime.Parse("Sep 19, 2014") },
                    new Parada { Ordem = 26, Latitude =  50.075538, Longitude =  14.437800, Nome = "Prague, Czech Republic", Chegada = DateTime.Parse("Sep 21, 2014") },
                    new Parada { Ordem = 27, Latitude =  51.050409, Longitude =  13.737262, Nome = "Dresden, Germany", Chegada = DateTime.Parse("Oct 1, 2014") },
                    new Parada { Ordem = 28, Latitude =  50.075538, Longitude =  14.437800, Nome = "Prague, Czech Republic", Chegada = DateTime.Parse("Oct 4, 2014") },
                    new Parada { Ordem = 29, Latitude =  42.650661, Longitude =  18.094424, Nome = "Dubrovnik, Croatia", Chegada = DateTime.Parse("Oct 10, 2014") },
                    new Parada { Ordem = 30, Latitude =  42.697708, Longitude =  23.321868, Nome = "Sofia, Bulgaria", Chegada = DateTime.Parse("Oct 16, 2014") },
                    new Parada { Ordem = 31, Latitude =  45.658928, Longitude =  25.539608, Nome = "Brosov, Romania", Chegada = DateTime.Parse("Oct 20, 2014") },
                    new Parada { Ordem = 32, Latitude =  41.005270, Longitude =  28.976960, Nome = "Istanbul, Turkey", Chegada = DateTime.Parse("Nov 1, 2014") },
                    new Parada { Ordem = 33, Latitude =  45.815011, Longitude =  15.981919, Nome = "Zagreb, Croatia", Chegada = DateTime.Parse("Nov 11, 2014") },
                    new Parada { Ordem = 34, Latitude =  41.005270, Longitude =  28.976960, Nome = "Istanbul, Turkey", Chegada = DateTime.Parse("Nov 15, 2014") },
                    new Parada { Ordem = 35, Latitude =  50.850000, Longitude =  4.350000, Nome = "Brussels, Belgium", Chegada = DateTime.Parse("Nov 25, 2014") },
                    new Parada { Ordem = 36, Latitude =  50.937531, Longitude =  6.960279, Nome = "Cologne, Germany", Chegada = DateTime.Parse("Nov 30, 2014") },
                    new Parada { Ordem = 37, Latitude =  48.208174, Longitude =  16.373819, Nome = "Vienna, Austria", Chegada = DateTime.Parse("Dec 4, 2014") },
                    new Parada { Ordem = 38, Latitude =  47.497912, Longitude =  19.040235, Nome = "Budapest, Hungary", Chegada = DateTime.Parse("Dec 28,2014") },
                    new Parada { Ordem = 39, Latitude =  37.983716, Longitude =  23.729310, Nome = "Athens, Greece", Chegada = DateTime.Parse("Jan 2, 2015") },
                    new Parada { Ordem = 40, Latitude =  -25.746111, Longitude =  28.188056, Nome = "Pretoria, South Africa", Chegada = DateTime.Parse("Jan 19, 2015") },
                    new Parada { Ordem = 41, Latitude =  43.771033, Longitude =  11.248001, Nome = "Florence, Italy", Chegada = DateTime.Parse("Feb 1, 2015") },
                    new Parada { Ordem = 42, Latitude =  45.440847, Longitude =  12.315515, Nome = "Venice, Italy", Chegada = DateTime.Parse("Feb 9, 2015") },
                    new Parada { Ordem = 43, Latitude =  43.771033, Longitude =  11.248001, Nome = "Florence, Italy", Chegada = DateTime.Parse("Feb 13, 2015") },
                    new Parada { Ordem = 44, Latitude =  41.872389, Longitude =  12.480180, Nome = "Rome, Italy", Chegada = DateTime.Parse("Feb 17, 2015") },
                    new Parada { Ordem = 45, Latitude =  28.632244, Longitude =  77.220724, Nome = "New Delhi, India", Chegada = DateTime.Parse("Mar 4, 2015") },
                    new Parada { Ordem = 46, Latitude =  27.700000, Longitude =  85.333333, Nome = "Kathmandu, Nepal", Chegada = DateTime.Parse("Mar 10, 2015") },
                    new Parada { Ordem = 47, Latitude =  28.632244, Longitude =  77.220724, Nome = "New Delhi, India", Chegada = DateTime.Parse("Mar 11, 2015") },
                    new Parada { Ordem = 48, Latitude =  22.1667, Longitude =  113.5500, Nome = "Macau", Chegada = DateTime.Parse("Mar 21, 2015") },
                    new Parada { Ordem = 49, Latitude =  22.396428, Longitude =  114.109497, Nome = "Hong Kong", Chegada = DateTime.Parse("Mar 24, 2015") },
                    new Parada { Ordem = 50, Latitude =  39.904030, Longitude =  116.407526, Nome = "Beijing, China", Chegada = DateTime.Parse("Apr 19, 2015") },
                    new Parada { Ordem = 51, Latitude =  22.396428, Longitude =  114.109497, Nome = "Hong Kong", Chegada = DateTime.Parse("Apr 24, 2015") },
                    new Parada { Ordem = 52, Latitude =  1.352083, Longitude =  103.819836, Nome = "Singapore", Chegada = DateTime.Parse("Apr 30, 2015") },
                    new Parada { Ordem = 53, Latitude =  3.139003, Longitude =  101.686855, Nome = "Kuala Lumpor, Malaysia", Chegada = DateTime.Parse("May 7, 2015") },
                    new Parada { Ordem = 54, Latitude =  13.727896, Longitude =  100.524123, Nome = "Bangkok, Thailand", Chegada = DateTime.Parse("May 24, 2015") },
                    new Parada { Ordem = 55, Latitude =  33.748995, Longitude =  -84.387982, Nome = "Atlanta, Georgia", Chegada = DateTime.Parse("Jun 17, 2015") },
                }
            };

            _viagemRepositorio.PostViagem(viagemAoMundo);
            _paradaRepositorio.PostListaParadas(viagemAoMundo.Paradas);

            _viagemRepositorio.SalvarAlteracoes();
        }
    }
}