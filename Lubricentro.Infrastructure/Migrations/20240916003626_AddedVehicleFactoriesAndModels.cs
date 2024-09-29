using Lubricentro.Domain.VehicleAggregates.Entities;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lubricentro.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedVehicleFactoriesAndModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            List<VehicleFactory> vehicleFactories = [];

            VehicleFactory AUDI = VehicleFactory.Create("AUDI");
            AUDI.AddVehicleModel(VehicleModel.Create("A1", true));
            AUDI.AddVehicleModel(VehicleModel.Create("A3", true));
            AUDI.AddVehicleModel(VehicleModel.Create("A4", true));
            AUDI.AddVehicleModel(VehicleModel.Create("A5", true));
            AUDI.AddVehicleModel(VehicleModel.Create("A6", true));
            AUDI.AddVehicleModel(VehicleModel.Create("A7", true));
            AUDI.AddVehicleModel(VehicleModel.Create("A8", true));
            AUDI.AddVehicleModel(VehicleModel.Create("ALLROAD", true));
            AUDI.AddVehicleModel(VehicleModel.Create("E-TRON", true));
            AUDI.AddVehicleModel(VehicleModel.Create("Q2", true));
            AUDI.AddVehicleModel(VehicleModel.Create("Q3", true));
            AUDI.AddVehicleModel(VehicleModel.Create("Q5", true));
            AUDI.AddVehicleModel(VehicleModel.Create("Q7", true));
            AUDI.AddVehicleModel(VehicleModel.Create("Q8", true));
            AUDI.AddVehicleModel(VehicleModel.Create("R8", true));
            AUDI.AddVehicleModel(VehicleModel.Create("TT", true));
            vehicleFactories.Add(AUDI);

            VehicleFactory BENELLI = VehicleFactory.Create("BENELLI");
            BENELLI.AddVehicleModel(VehicleModel.Create("ADVENTURE", true));
            BENELLI.AddVehicleModel(VehicleModel.Create("CLASSIC", true));
            BENELLI.AddVehicleModel(VehicleModel.Create("SPORT", true));
            BENELLI.AddVehicleModel(VehicleModel.Create("SPORT HERITAGE", true));
            BENELLI.AddVehicleModel(VehicleModel.Create("STREET - NAKED", true));
            vehicleFactories.Add(BENELLI);


            VehicleFactory BMW = VehicleFactory.Create("BMW");
            BMW.AddVehicleModel(VehicleModel.Create("SERIE 1", true));
            BMW.AddVehicleModel(VehicleModel.Create("SERIE 2", true));
            BMW.AddVehicleModel(VehicleModel.Create("SERIE 3", true));
            BMW.AddVehicleModel(VehicleModel.Create("SERIE 4", true));
            BMW.AddVehicleModel(VehicleModel.Create("SERIE 5", true));
            BMW.AddVehicleModel(VehicleModel.Create("SERIE 6", true));
            BMW.AddVehicleModel(VehicleModel.Create("SERIE 7", true));
            BMW.AddVehicleModel(VehicleModel.Create("SERIE 8", true));
            BMW.AddVehicleModel(VehicleModel.Create("X1", true));
            BMW.AddVehicleModel(VehicleModel.Create("X2", true));
            BMW.AddVehicleModel(VehicleModel.Create("X3", true));
            BMW.AddVehicleModel(VehicleModel.Create("X4", true));
            BMW.AddVehicleModel(VehicleModel.Create("X5", true));
            BMW.AddVehicleModel(VehicleModel.Create("X6", true));
            BMW.AddVehicleModel(VehicleModel.Create("X7", true));
            BMW.AddVehicleModel(VehicleModel.Create("Z4", true));

            BMW.AddVehicleModel(VehicleModel.Create("ADVENTURE", true));
            BMW.AddVehicleModel(VehicleModel.Create("HERITAGE", true));
            BMW.AddVehicleModel(VehicleModel.Create("R NINE T", true));
            BMW.AddVehicleModel(VehicleModel.Create("SPORT", true));
            BMW.AddVehicleModel(VehicleModel.Create("TOUR", true));
            BMW.AddVehicleModel(VehicleModel.Create("URBAN", true));
            vehicleFactories.Add(BMW);

            VehicleFactory CASE = VehicleFactory.Create("CASE");
            vehicleFactories.Add(CASE);

            VehicleFactory CHANGAN = VehicleFactory.Create("CHANGAN");
            CHANGAN.AddVehicleModel(VehicleModel.Create("CS15", true));
            CHANGAN.AddVehicleModel(VehicleModel.Create("CS75", true));
            CHANGAN.AddVehicleModel(VehicleModel.Create("UTILITARIOS", true));
            vehicleFactories.Add(CHANGAN);

            VehicleFactory CHERY = VehicleFactory.Create("CHERY");
            CHERY.AddVehicleModel(VehicleModel.Create("ARRIZO 5", true));
            CHERY.AddVehicleModel(VehicleModel.Create("FACE", true));
            CHERY.AddVehicleModel(VehicleModel.Create("FULWIN", true));
            CHERY.AddVehicleModel(VehicleModel.Create("FULWIN 2", true));
            CHERY.AddVehicleModel(VehicleModel.Create("QQ", true));
            CHERY.AddVehicleModel(VehicleModel.Create("SKIN", true));
            CHERY.AddVehicleModel(VehicleModel.Create("TIGGO", true));
            CHERY.AddVehicleModel(VehicleModel.Create("TIGGO 2", true));
            CHERY.AddVehicleModel(VehicleModel.Create("TIGGO 2 PRO", true));
            CHERY.AddVehicleModel(VehicleModel.Create("TIGGO 3", true));
            CHERY.AddVehicleModel(VehicleModel.Create("TIGGO 4", true));
            CHERY.AddVehicleModel(VehicleModel.Create("TIGGO 5", true));
            CHERY.AddVehicleModel(VehicleModel.Create("TIGGO 8 PRO", true));
            vehicleFactories.Add(CHERY);

            VehicleFactory CHEVROLET = VehicleFactory.Create("CHEVROLET");
            CHEVROLET.AddVehicleModel(VehicleModel.Create("AGILE", true));
            CHEVROLET.AddVehicleModel(VehicleModel.Create("ASTRA II", true));
            CHEVROLET.AddVehicleModel(VehicleModel.Create("AVEO", true));
            CHEVROLET.AddVehicleModel(VehicleModel.Create("BLAZER", true));
            CHEVROLET.AddVehicleModel(VehicleModel.Create("CAMARO", true));
            CHEVROLET.AddVehicleModel(VehicleModel.Create("CAPTIVA", true));
            CHEVROLET.AddVehicleModel(VehicleModel.Create("CELTA", true));
            CHEVROLET.AddVehicleModel(VehicleModel.Create("CLASSIC", true));
            CHEVROLET.AddVehicleModel(VehicleModel.Create("COBALT", true));
            CHEVROLET.AddVehicleModel(VehicleModel.Create("CORSA CLASSIC", true));
            CHEVROLET.AddVehicleModel(VehicleModel.Create("CORSA II", true));
            CHEVROLET.AddVehicleModel(VehicleModel.Create("CORVETTE", true));
            CHEVROLET.AddVehicleModel(VehicleModel.Create("CRUZE", true));
            CHEVROLET.AddVehicleModel(VehicleModel.Create("CRUZE II", true));
            CHEVROLET.AddVehicleModel(VehicleModel.Create("EQUINOX", true));
            CHEVROLET.AddVehicleModel(VehicleModel.Create("MERIVA", true));
            CHEVROLET.AddVehicleModel(VehicleModel.Create("MONTANA", true));
            CHEVROLET.AddVehicleModel(VehicleModel.Create("ONIX", true));
            CHEVROLET.AddVehicleModel(VehicleModel.Create("PRISMA", true));
            CHEVROLET.AddVehicleModel(VehicleModel.Create("S-10", true));
            CHEVROLET.AddVehicleModel(VehicleModel.Create("SONIC", true));
            CHEVROLET.AddVehicleModel(VehicleModel.Create("SPARK", true));
            CHEVROLET.AddVehicleModel(VehicleModel.Create("SPIN", true));
            CHEVROLET.AddVehicleModel(VehicleModel.Create("TRACKER", true));
            CHEVROLET.AddVehicleModel(VehicleModel.Create("TRAILBLAZER", true));
            CHEVROLET.AddVehicleModel(VehicleModel.Create("VECTRA", true));
            CHEVROLET.AddVehicleModel(VehicleModel.Create("ZAFIRA", true));
            vehicleFactories.Add(CHEVROLET);

            VehicleFactory CITROEN = VehicleFactory.Create("CITROEN");
            CITROEN.AddVehicleModel(VehicleModel.Create("BERLINGO", true));
            CITROEN.AddVehicleModel(VehicleModel.Create("C-ELYSEE", true));
            CITROEN.AddVehicleModel(VehicleModel.Create("C3", true));
            CITROEN.AddVehicleModel(VehicleModel.Create("C3 AIRCROSS", true));
            CITROEN.AddVehicleModel(VehicleModel.Create("C3 PICASSO", true));
            CITROEN.AddVehicleModel(VehicleModel.Create("C4", true));
            CITROEN.AddVehicleModel(VehicleModel.Create("C4 AIRCROSS", true));
            CITROEN.AddVehicleModel(VehicleModel.Create("C4 CACTUS", true));
            CITROEN.AddVehicleModel(VehicleModel.Create("C4 GRAND PICASSO", true));
            CITROEN.AddVehicleModel(VehicleModel.Create("C4 LOUNGE", true));
            CITROEN.AddVehicleModel(VehicleModel.Create("C4 PICASSO", true));
            CITROEN.AddVehicleModel(VehicleModel.Create("C4 SPACETOURER", true));
            CITROEN.AddVehicleModel(VehicleModel.Create("C5", true));
            CITROEN.AddVehicleModel(VehicleModel.Create("C5 AIRCROSS", true));
            CITROEN.AddVehicleModel(VehicleModel.Create("C6", true));
            CITROEN.AddVehicleModel(VehicleModel.Create("GRAND C4 SPACETOURER", true));
            CITROEN.AddVehicleModel(VehicleModel.Create("JUMPER", true));
            CITROEN.AddVehicleModel(VehicleModel.Create("JUMPY", true));
            CITROEN.AddVehicleModel(VehicleModel.Create("SPACETOURER", true));
            CITROEN.AddVehicleModel(VehicleModel.Create("XSARA PICASSO", true));
            vehicleFactories.Add(CITROEN);

            VehicleFactory DAIHATSU = VehicleFactory.Create("DAIHATSU");
            vehicleFactories.Add(DAIHATSU);

            VehicleFactory DEUTZ = VehicleFactory.Create("DEUTZ");
            vehicleFactories.Add(DEUTZ);

            VehicleFactory DFM = VehicleFactory.Create("DFM");
            DFM.AddVehicleModel(VehicleModel.Create("CAMION LIVIANO", false));
            vehicleFactories.Add(DFM);

            VehicleFactory DODGE = VehicleFactory.Create("DODGE");
            DODGE.AddVehicleModel(VehicleModel.Create("JOURNEY", true));
            DODGE.AddVehicleModel(VehicleModel.Create("RAM", true));
            vehicleFactories.Add(DODGE);

            VehicleFactory FIAT = VehicleFactory.Create("FIAT");
            FIAT.AddVehicleModel(VehicleModel.Create("500", true));
            FIAT.AddVehicleModel(VehicleModel.Create("500X", true));
            FIAT.AddVehicleModel(VehicleModel.Create("ARGO", true));
            FIAT.AddVehicleModel(VehicleModel.Create("BRAVO", true));
            FIAT.AddVehicleModel(VehicleModel.Create("CRONOS", true));
            FIAT.AddVehicleModel(VehicleModel.Create("DOBLO", true));
            FIAT.AddVehicleModel(VehicleModel.Create("DUCATO", true));
            FIAT.AddVehicleModel(VehicleModel.Create("FASTBACK", true));
            FIAT.AddVehicleModel(VehicleModel.Create("FIORINO", true));
            FIAT.AddVehicleModel(VehicleModel.Create("FIORINO QUBO", true));
            FIAT.AddVehicleModel(VehicleModel.Create("GRAND SIENA", true));
            FIAT.AddVehicleModel(VehicleModel.Create("IDEA", true));
            FIAT.AddVehicleModel(VehicleModel.Create("LINEA", true));
            FIAT.AddVehicleModel(VehicleModel.Create("MOBI", true));
            FIAT.AddVehicleModel(VehicleModel.Create("PALIO", true));
            FIAT.AddVehicleModel(VehicleModel.Create("PALIO ADVENTURE", true));
            FIAT.AddVehicleModel(VehicleModel.Create("PULSE", true));
            FIAT.AddVehicleModel(VehicleModel.Create("PUNTO", true));
            FIAT.AddVehicleModel(VehicleModel.Create("QUBO", true));
            FIAT.AddVehicleModel(VehicleModel.Create("SIENA", true));
            FIAT.AddVehicleModel(VehicleModel.Create("STILO", true));
            FIAT.AddVehicleModel(VehicleModel.Create("STRADA", true));
            FIAT.AddVehicleModel(VehicleModel.Create("TIPO", true));
            FIAT.AddVehicleModel(VehicleModel.Create("TORO", true));
            FIAT.AddVehicleModel(VehicleModel.Create("UNO", true));
            FIAT.AddVehicleModel(VehicleModel.Create("UNO EVO", true));
            FIAT.AddVehicleModel(VehicleModel.Create("WEEKEND", true));
            vehicleFactories.Add(FIAT);

            VehicleFactory FORD = VehicleFactory.Create("FORD");
            FORD.AddVehicleModel(VehicleModel.Create("BRONCO", true));
            FORD.AddVehicleModel(VehicleModel.Create("COURIER", true));
            FORD.AddVehicleModel(VehicleModel.Create("ECOSPORT", true));
            FORD.AddVehicleModel(VehicleModel.Create("ECOSPORT KD", true));
            FORD.AddVehicleModel(VehicleModel.Create("F-100", true));
            FORD.AddVehicleModel(VehicleModel.Create("F-150", true));
            FORD.AddVehicleModel(VehicleModel.Create("FIESTA", true));
            FORD.AddVehicleModel(VehicleModel.Create("FIESTA KD", true));
            FORD.AddVehicleModel(VehicleModel.Create("FOCUS", true));
            FORD.AddVehicleModel(VehicleModel.Create("FOCUS III", true));
            FORD.AddVehicleModel(VehicleModel.Create("KA", true));
            FORD.AddVehicleModel(VehicleModel.Create("KUGA", true));
            FORD.AddVehicleModel(VehicleModel.Create("MAVERICK", true));
            FORD.AddVehicleModel(VehicleModel.Create("MONDEO", true));
            FORD.AddVehicleModel(VehicleModel.Create("MUSTANG", true));
            FORD.AddVehicleModel(VehicleModel.Create("MUSTANG MACH-E", true));
            FORD.AddVehicleModel(VehicleModel.Create("RANGER", true));
            FORD.AddVehicleModel(VehicleModel.Create("S-MAX", true));
            FORD.AddVehicleModel(VehicleModel.Create("TERRITORY", true));
            FORD.AddVehicleModel(VehicleModel.Create("TRANSIT", true));

            FORD.AddVehicleModel(VehicleModel.Create("CARGO", false));
            FORD.AddVehicleModel(VehicleModel.Create("F-4000", false));
            vehicleFactories.Add(FORD);

            VehicleFactory HANGCHA = VehicleFactory.Create("HANGCHA");
            vehicleFactories.Add(HANGCHA);

            VehicleFactory HONDA = VehicleFactory.Create("HONDA");
            HONDA.AddVehicleModel(VehicleModel.Create("ACCORD", true));
            HONDA.AddVehicleModel(VehicleModel.Create("CITY", true));
            HONDA.AddVehicleModel(VehicleModel.Create("CIVIC", true));
            HONDA.AddVehicleModel(VehicleModel.Create("CRV", true));
            HONDA.AddVehicleModel(VehicleModel.Create("FIT", true));
            HONDA.AddVehicleModel(VehicleModel.Create("HR-V", true));
            HONDA.AddVehicleModel(VehicleModel.Create("LEGEND", true));
            HONDA.AddVehicleModel(VehicleModel.Create("PILOT", true));
            HONDA.AddVehicleModel(VehicleModel.Create("WR-V", true));
            HONDA.AddVehicleModel(VehicleModel.Create("ZR-V", true));

            HONDA.AddVehicleModel(VehicleModel.Create("ATV", true));
            HONDA.AddVehicleModel(VehicleModel.Create("BUSINESS", true));
            HONDA.AddVehicleModel(VehicleModel.Create("ON-OFF", true));
            HONDA.AddVehicleModel(VehicleModel.Create("SCOOTER", true));
            HONDA.AddVehicleModel(VehicleModel.Create("SPORT", true));
            HONDA.AddVehicleModel(VehicleModel.Create("TOURING", true));
            vehicleFactories.Add(HONDA);

            VehicleFactory HYUNDAI = VehicleFactory.Create("HYUNDAI");
            HYUNDAI.AddVehicleModel(VehicleModel.Create("ATOS PRIME", true));
            HYUNDAI.AddVehicleModel(VehicleModel.Create("COUPE", true));
            HYUNDAI.AddVehicleModel(VehicleModel.Create("CRETA", true));
            HYUNDAI.AddVehicleModel(VehicleModel.Create("ELANTRA", true));
            HYUNDAI.AddVehicleModel(VehicleModel.Create("GRAND I10", true));
            HYUNDAI.AddVehicleModel(VehicleModel.Create("GRAND SANTA FE", true));
            HYUNDAI.AddVehicleModel(VehicleModel.Create("H1", true));
            HYUNDAI.AddVehicleModel(VehicleModel.Create("I10", true));
            HYUNDAI.AddVehicleModel(VehicleModel.Create("I30", true));
            HYUNDAI.AddVehicleModel(VehicleModel.Create("IONIQ", true));
            HYUNDAI.AddVehicleModel(VehicleModel.Create("KONA", true));
            HYUNDAI.AddVehicleModel(VehicleModel.Create("SANTA FE", true));
            HYUNDAI.AddVehicleModel(VehicleModel.Create("STARIA", true));
            HYUNDAI.AddVehicleModel(VehicleModel.Create("TUCSON", true));
            HYUNDAI.AddVehicleModel(VehicleModel.Create("VELOSTER", true));
            HYUNDAI.AddVehicleModel(VehicleModel.Create("VERACRUZ", true));

            HYUNDAI.AddVehicleModel(VehicleModel.Create("H 100", false));
            HYUNDAI.AddVehicleModel(VehicleModel.Create("H 350", false));
            HYUNDAI.AddVehicleModel(VehicleModel.Create("HD65", false));
            HYUNDAI.AddVehicleModel(VehicleModel.Create("HD78", false));
            vehicleFactories.Add(HYUNDAI);


            VehicleFactory ISUZU = VehicleFactory.Create("ISUZU");
            ISUZU.AddVehicleModel(VehicleModel.Create("D-MAX KENZU", true));

            ISUZU.AddVehicleModel(VehicleModel.Create("NPR 75", false));
            ISUZU.AddVehicleModel(VehicleModel.Create("NQR90", false));
            vehicleFactories.Add(ISUZU);

            VehicleFactory IVECO = VehicleFactory.Create("IVECO");
            IVECO.AddVehicleModel(VehicleModel.Create("CURSOR", false));
            IVECO.AddVehicleModel(VehicleModel.Create("CURSOR EU5", false));
            IVECO.AddVehicleModel(VehicleModel.Create("EURO CARGO", false));
            IVECO.AddVehicleModel(VehicleModel.Create("EURO CARGO CAVALLINO", false));
            IVECO.AddVehicleModel(VehicleModel.Create("NEW TECTOR", false));
            IVECO.AddVehicleModel(VehicleModel.Create("NUEVO TECTOR", false));
            IVECO.AddVehicleModel(VehicleModel.Create("STRALIS", false));
            IVECO.AddVehicleModel(VehicleModel.Create("STRALIS EU5", false));
            IVECO.AddVehicleModel(VehicleModel.Create("TECTOR", false));
            IVECO.AddVehicleModel(VehicleModel.Create("TECTOR EU5", false));
            IVECO.AddVehicleModel(VehicleModel.Create("TRAKKER", false));
            IVECO.AddVehicleModel(VehicleModel.Create("VERTIS", false));
            vehicleFactories.Add(IVECO);
            
            VehicleFactory JEEP = VehicleFactory.Create("JEEP");
            JEEP.AddVehicleModel(VehicleModel.Create("CHEROKEE", true));
            JEEP.AddVehicleModel(VehicleModel.Create("COMMANDER", true));
            JEEP.AddVehicleModel(VehicleModel.Create("COMPASS", true));
            JEEP.AddVehicleModel(VehicleModel.Create("GLADIADOR", true));
            JEEP.AddVehicleModel(VehicleModel.Create("GRAND CHEROKEE", true));
            JEEP.AddVehicleModel(VehicleModel.Create("PATRIOT", true));
            JEEP.AddVehicleModel(VehicleModel.Create("RENEGADE", true));
            JEEP.AddVehicleModel(VehicleModel.Create("WRANGLER", true));
            vehicleFactories.Add(JEEP);

            VehicleFactory JHON_DEERE = VehicleFactory.Create("JHON DEERE");
            vehicleFactories.Add(JHON_DEERE);

            VehicleFactory KIA = VehicleFactory.Create("KIA");
            KIA.AddVehicleModel(VehicleModel.Create("CARNIVAL", true));
            KIA.AddVehicleModel(VehicleModel.Create("CERATO", true));
            KIA.AddVehicleModel(VehicleModel.Create("MAGENTIS", true));
            KIA.AddVehicleModel(VehicleModel.Create("MOHAVE", true));
            KIA.AddVehicleModel(VehicleModel.Create("OPIRUS", true));
            KIA.AddVehicleModel(VehicleModel.Create("PICANTO", true));
            KIA.AddVehicleModel(VehicleModel.Create("RIO", true));
            KIA.AddVehicleModel(VehicleModel.Create("RONDO", true));
            KIA.AddVehicleModel(VehicleModel.Create("SELTOS", true));
            KIA.AddVehicleModel(VehicleModel.Create("SORENTO", true));
            KIA.AddVehicleModel(VehicleModel.Create("SOUL", true));
            KIA.AddVehicleModel(VehicleModel.Create("SPORTAGE", true));

            KIA.AddVehicleModel(VehicleModel.Create("K-2500", false));
            KIA.AddVehicleModel(VehicleModel.Create("K-2700", false));
            KIA.AddVehicleModel(VehicleModel.Create("K-2900", false));
            vehicleFactories.Add(KIA);

            VehicleFactory MASSEY_FERGUSON = VehicleFactory.Create("MASSEY FERGUSON");
            vehicleFactories.Add(MASSEY_FERGUSON);

            VehicleFactory MERCEDES_BENZ = VehicleFactory.Create("MERCEDES BENZ");
            MERCEDES_BENZ.AddVehicleModel(VehicleModel.Create("AMG", true));
            MERCEDES_BENZ.AddVehicleModel(VehicleModel.Create("CLASE A", true));
            MERCEDES_BENZ.AddVehicleModel(VehicleModel.Create("CLASE B", true));
            MERCEDES_BENZ.AddVehicleModel(VehicleModel.Create("CLASE C", true));
            MERCEDES_BENZ.AddVehicleModel(VehicleModel.Create("CLASE CLA", true));
            MERCEDES_BENZ.AddVehicleModel(VehicleModel.Create("CLASE CLC", true));
            MERCEDES_BENZ.AddVehicleModel(VehicleModel.Create("CLASE CLK", true));
            MERCEDES_BENZ.AddVehicleModel(VehicleModel.Create("CLASE CLS", true));
            MERCEDES_BENZ.AddVehicleModel(VehicleModel.Create("CLASE E", true));
            MERCEDES_BENZ.AddVehicleModel(VehicleModel.Create("CLASE G", true));
            MERCEDES_BENZ.AddVehicleModel(VehicleModel.Create("CLASE GL", true));
            MERCEDES_BENZ.AddVehicleModel(VehicleModel.Create("CLASE GLA", true));
            MERCEDES_BENZ.AddVehicleModel(VehicleModel.Create("CLASE GLB", true));
            MERCEDES_BENZ.AddVehicleModel(VehicleModel.Create("CLASE GLC", true));
            MERCEDES_BENZ.AddVehicleModel(VehicleModel.Create("CLASE GLE", true));
            MERCEDES_BENZ.AddVehicleModel(VehicleModel.Create("CLASE GLK", true));
            MERCEDES_BENZ.AddVehicleModel(VehicleModel.Create("CLASE GLS", true));
            MERCEDES_BENZ.AddVehicleModel(VehicleModel.Create("CLASE ML", true));
            MERCEDES_BENZ.AddVehicleModel(VehicleModel.Create("CLASE S", true));
            MERCEDES_BENZ.AddVehicleModel(VehicleModel.Create("CLASE SL", true));
            MERCEDES_BENZ.AddVehicleModel(VehicleModel.Create("CLASE SLK", true));
            MERCEDES_BENZ.AddVehicleModel(VehicleModel.Create("EQA", true));
            MERCEDES_BENZ.AddVehicleModel(VehicleModel.Create("VIANO", true));
            MERCEDES_BENZ.AddVehicleModel(VehicleModel.Create("VITO", true));

            MERCEDES_BENZ.AddVehicleModel(VehicleModel.Create("BUSES", false));
            MERCEDES_BENZ.AddVehicleModel(VehicleModel.Create("LIVIANOS", false));
            MERCEDES_BENZ.AddVehicleModel(VehicleModel.Create("MEDIANOS", false));
            MERCEDES_BENZ.AddVehicleModel(VehicleModel.Create("PESADOS", false));
            MERCEDES_BENZ.AddVehicleModel(VehicleModel.Create("SEMIPESADOS", false));
            MERCEDES_BENZ.AddVehicleModel(VehicleModel.Create("SPRINTER", false));
            vehicleFactories.Add(MERCEDES_BENZ);

            VehicleFactory MINI = VehicleFactory.Create("MINI");
            MINI.AddVehicleModel(VehicleModel.Create("COOPER", true));
            vehicleFactories.Add(MINI);

            VehicleFactory MITSUBISHI = VehicleFactory.Create("MITSUBISHI");
            MITSUBISHI.AddVehicleModel(VehicleModel.Create("L-200", true));
            MITSUBISHI.AddVehicleModel(VehicleModel.Create("LANCER", true));
            MITSUBISHI.AddVehicleModel(VehicleModel.Create("MONTERO", true));
            MITSUBISHI.AddVehicleModel(VehicleModel.Create("OUTLANDER", true));
            vehicleFactories.Add(MITSUBISHI);

            VehicleFactory NEW_HOLLAND = VehicleFactory.Create("NEW HOLLAND");
            vehicleFactories.Add(NEW_HOLLAND);

            VehicleFactory NISSAN = VehicleFactory.Create("NISSAN");
            NISSAN.AddVehicleModel(VehicleModel.Create("350", true));
            NISSAN.AddVehicleModel(VehicleModel.Create("370Z", true));
            NISSAN.AddVehicleModel(VehicleModel.Create("ALTIMA", true));
            NISSAN.AddVehicleModel(VehicleModel.Create("FRONTIER", true));
            NISSAN.AddVehicleModel(VehicleModel.Create("KICKS", true));
            NISSAN.AddVehicleModel(VehicleModel.Create("LEAF", true));
            NISSAN.AddVehicleModel(VehicleModel.Create("MARCH", true));
            NISSAN.AddVehicleModel(VehicleModel.Create("MURANO", true));
            NISSAN.AddVehicleModel(VehicleModel.Create("NOTE", true));
            NISSAN.AddVehicleModel(VehicleModel.Create("NP300", true));
            NISSAN.AddVehicleModel(VehicleModel.Create("PATHFINDER", true));
            NISSAN.AddVehicleModel(VehicleModel.Create("SENTRA", true));
            NISSAN.AddVehicleModel(VehicleModel.Create("TEANA", true));
            NISSAN.AddVehicleModel(VehicleModel.Create("TIIDA", true));
            NISSAN.AddVehicleModel(VehicleModel.Create("VERSA", true));
            NISSAN.AddVehicleModel(VehicleModel.Create("X-TERRA", true));
            NISSAN.AddVehicleModel(VehicleModel.Create("X-TRAIL", true));
            vehicleFactories.Add(NISSAN);

            VehicleFactory PEUGOT = VehicleFactory.Create("PEUGOT");
            PEUGOT.AddVehicleModel(VehicleModel.Create("2008", true));
            PEUGOT.AddVehicleModel(VehicleModel.Create("206", true));
            PEUGOT.AddVehicleModel(VehicleModel.Create("207", true));
            PEUGOT.AddVehicleModel(VehicleModel.Create("208", true));
            PEUGOT.AddVehicleModel(VehicleModel.Create("3008", true));
            PEUGOT.AddVehicleModel(VehicleModel.Create("301", true));
            PEUGOT.AddVehicleModel(VehicleModel.Create("307", true));
            PEUGOT.AddVehicleModel(VehicleModel.Create("308", true));
            PEUGOT.AddVehicleModel(VehicleModel.Create("4008", true));
            PEUGOT.AddVehicleModel(VehicleModel.Create("407", true));
            PEUGOT.AddVehicleModel(VehicleModel.Create("408", true));
            PEUGOT.AddVehicleModel(VehicleModel.Create("5008", true));
            PEUGOT.AddVehicleModel(VehicleModel.Create("508", true));
            PEUGOT.AddVehicleModel(VehicleModel.Create("607", true));
            PEUGOT.AddVehicleModel(VehicleModel.Create("807", true));
            PEUGOT.AddVehicleModel(VehicleModel.Create("BOXER", true));
            PEUGOT.AddVehicleModel(VehicleModel.Create("EXPERT", true));
            PEUGOT.AddVehicleModel(VehicleModel.Create("HOGGAR", true));
            PEUGOT.AddVehicleModel(VehicleModel.Create("PARTNER", true));
            PEUGOT.AddVehicleModel(VehicleModel.Create("RCZ", true));
            PEUGOT.AddVehicleModel(VehicleModel.Create("TRAVELLER", true));
            vehicleFactories.Add(PEUGOT);

            VehicleFactory RASTROJERO = VehicleFactory.Create("RASTROJERO");
            vehicleFactories.Add(RASTROJERO);

            VehicleFactory RENAULT = VehicleFactory.Create("RENAULT");
            RENAULT.AddVehicleModel(VehicleModel.Create("ALASKAN", true));
            RENAULT.AddVehicleModel(VehicleModel.Create("CAPTUR", true));
            RENAULT.AddVehicleModel(VehicleModel.Create("CLIO L/NUEVA", true));
            RENAULT.AddVehicleModel(VehicleModel.Create("CLIO MIO", true));
            RENAULT.AddVehicleModel(VehicleModel.Create("DUSTER", true));
            RENAULT.AddVehicleModel(VehicleModel.Create("FLUENCE", true));
            RENAULT.AddVehicleModel(VehicleModel.Create("KANGOO", true));
            RENAULT.AddVehicleModel(VehicleModel.Create("KANGOO E-TECH", true));
            RENAULT.AddVehicleModel(VehicleModel.Create("KANGOO FURGON", true));
            RENAULT.AddVehicleModel(VehicleModel.Create("KANGOO II", true));
            RENAULT.AddVehicleModel(VehicleModel.Create("KANGOO II EXPRESS", true));
            RENAULT.AddVehicleModel(VehicleModel.Create("KANGOO Z.E.", true));
            RENAULT.AddVehicleModel(VehicleModel.Create("KARDIAN", true));
            RENAULT.AddVehicleModel(VehicleModel.Create("KOLEOS", true));
            RENAULT.AddVehicleModel(VehicleModel.Create("KWID", true));
            RENAULT.AddVehicleModel(VehicleModel.Create("LATITUDE", true));
            RENAULT.AddVehicleModel(VehicleModel.Create("LOGAN", true));
            RENAULT.AddVehicleModel(VehicleModel.Create("MASTER", true));
            RENAULT.AddVehicleModel(VehicleModel.Create("MEGANE", true));
            RENAULT.AddVehicleModel(VehicleModel.Create("MEGANE E-TECH", true));
            RENAULT.AddVehicleModel(VehicleModel.Create("MEGANE II", true));
            RENAULT.AddVehicleModel(VehicleModel.Create("MEGANE III", true));
            RENAULT.AddVehicleModel(VehicleModel.Create("OROCH", true));
            RENAULT.AddVehicleModel(VehicleModel.Create("SANDERO", true));
            RENAULT.AddVehicleModel(VehicleModel.Create("SANDERO STEPWAY", true));
            RENAULT.AddVehicleModel(VehicleModel.Create("SCENIC", true));
            RENAULT.AddVehicleModel(VehicleModel.Create("SYMBOL", true));

            RENAULT.AddVehicleModel(VehicleModel.Create("KERAX", false));
            RENAULT.AddVehicleModel(VehicleModel.Create("MIDLUM", false));
            RENAULT.AddVehicleModel(VehicleModel.Create("PREMIUM", false));
            vehicleFactories.Add(RENAULT);

            VehicleFactory SCANIA = VehicleFactory.Create("SCANIA");
            SCANIA.AddVehicleModel(VehicleModel.Create("BUSES", false));
            SCANIA.AddVehicleModel(VehicleModel.Create("NTG", false));
            SCANIA.AddVehicleModel(VehicleModel.Create("PGR MOTORES DL CONSTRUCCION", false));
            SCANIA.AddVehicleModel(VehicleModel.Create("PGR MOTORES DL DISTRIBUCION", false));
            SCANIA.AddVehicleModel(VehicleModel.Create("PGR MOTORES DL LARGA DISTANCIA", false));
            SCANIA.AddVehicleModel(VehicleModel.Create("PGR MOTORES EU5 CONSTRUCCION", false));
            SCANIA.AddVehicleModel(VehicleModel.Create("PGR MOTORES EU5 GENERAL", false));
            SCANIA.AddVehicleModel(VehicleModel.Create("PGR MOTORES EU5 DISTRIBUCION", false));
            SCANIA.AddVehicleModel(VehicleModel.Create("SERIE PGR CONSTRUCCION", false));
            SCANIA.AddVehicleModel(VehicleModel.Create("SERIE PGR LARGA DISTANCIA", false));
            vehicleFactories.Add(SCANIA);

            VehicleFactory SEAT = VehicleFactory.Create("SEAT");
            SEAT.AddVehicleModel(VehicleModel.Create("ALETA", true));
            SEAT.AddVehicleModel(VehicleModel.Create("CORDOBA", true));
            SEAT.AddVehicleModel(VehicleModel.Create("IBIZA", true));
            SEAT.AddVehicleModel(VehicleModel.Create("LEON", true));
            SEAT.AddVehicleModel(VehicleModel.Create("TOLEDO", true));
            vehicleFactories.Add(SEAT);

            VehicleFactory SUZUKI = VehicleFactory.Create("SUZUKI");
            SUZUKI.AddVehicleModel(VehicleModel.Create("BALENO", true));
            SUZUKI.AddVehicleModel(VehicleModel.Create("FUN", true));
            SUZUKI.AddVehicleModel(VehicleModel.Create("GRAND VITARA", true));
            SUZUKI.AddVehicleModel(VehicleModel.Create("JIMNY", true));
            SUZUKI.AddVehicleModel(VehicleModel.Create("NEW VITARA", true));
            SUZUKI.AddVehicleModel(VehicleModel.Create("SWIFT", true));

            SUZUKI.AddVehicleModel(VehicleModel.Create("OFF-ROAD/ADVENTURE", true));
            SUZUKI.AddVehicleModel(VehicleModel.Create("STREET/SPORT", true));
            SUZUKI.AddVehicleModel(VehicleModel.Create("SUPERSPORT", true));
            vehicleFactories.Add(SUZUKI);

            VehicleFactory TOYOTA = VehicleFactory.Create("TOYOTA");
            TOYOTA.AddVehicleModel(VehicleModel.Create("86", true));
            TOYOTA.AddVehicleModel(VehicleModel.Create("AVENSIS", true));
            TOYOTA.AddVehicleModel(VehicleModel.Create("C-HR HYBRID", true));
            TOYOTA.AddVehicleModel(VehicleModel.Create("CAMRY", true));
            TOYOTA.AddVehicleModel(VehicleModel.Create("COROLLA", true));
            TOYOTA.AddVehicleModel(VehicleModel.Create("COROLLA CROSS", true));
            TOYOTA.AddVehicleModel(VehicleModel.Create("CROWN", true));
            TOYOTA.AddVehicleModel(VehicleModel.Create("ETIOS", true));
            TOYOTA.AddVehicleModel(VehicleModel.Create("ETIOS CROSS", true));
            TOYOTA.AddVehicleModel(VehicleModel.Create("HIACE", true));
            TOYOTA.AddVehicleModel(VehicleModel.Create("HILUX", true));
            TOYOTA.AddVehicleModel(VehicleModel.Create("INNOVA", true));
            TOYOTA.AddVehicleModel(VehicleModel.Create("LAND CRUISER", true));
            TOYOTA.AddVehicleModel(VehicleModel.Create("PRIUS", true));
            TOYOTA.AddVehicleModel(VehicleModel.Create("RAV 4", true));
            TOYOTA.AddVehicleModel(VehicleModel.Create("SUPRA", true));
            TOYOTA.AddVehicleModel(VehicleModel.Create("YARIS", true));
            vehicleFactories.Add(TOYOTA);

            VehicleFactory VALTRA = VehicleFactory.Create("VALTRA");
            vehicleFactories.Add(VALTRA);

            VehicleFactory VOLKSWAGEN = VehicleFactory.Create("VOLKSWAGEN");
            VOLKSWAGEN.AddVehicleModel(VehicleModel.Create("AMAROK", true));
            VOLKSWAGEN.AddVehicleModel(VehicleModel.Create("BORA", true));
            VOLKSWAGEN.AddVehicleModel(VehicleModel.Create("CADDY", true));
            VOLKSWAGEN.AddVehicleModel(VehicleModel.Create("CC", true));
            VOLKSWAGEN.AddVehicleModel(VehicleModel.Create("CROSSFOX", true));
            VOLKSWAGEN.AddVehicleModel(VehicleModel.Create("FOX", true));
            VOLKSWAGEN.AddVehicleModel(VehicleModel.Create("GOL", true));
            VOLKSWAGEN.AddVehicleModel(VehicleModel.Create("GOL TREND", true));
            VOLKSWAGEN.AddVehicleModel(VehicleModel.Create("GOLF", true));
            VOLKSWAGEN.AddVehicleModel(VehicleModel.Create("MULTIVAN", true));
            VOLKSWAGEN.AddVehicleModel(VehicleModel.Create("NEW BEETLE", true));
            VOLKSWAGEN.AddVehicleModel(VehicleModel.Create("NIVUS", true));
            VOLKSWAGEN.AddVehicleModel(VehicleModel.Create("PASSAT", true));
            VOLKSWAGEN.AddVehicleModel(VehicleModel.Create("POLO", true));
            VOLKSWAGEN.AddVehicleModel(VehicleModel.Create("SAVEIRO", true));
            VOLKSWAGEN.AddVehicleModel(VehicleModel.Create("SCIROCCO", true));
            VOLKSWAGEN.AddVehicleModel(VehicleModel.Create("SHARAN", true));
            VOLKSWAGEN.AddVehicleModel(VehicleModel.Create("SURAN", true));
            VOLKSWAGEN.AddVehicleModel(VehicleModel.Create("T-CROSS", true));
            VOLKSWAGEN.AddVehicleModel(VehicleModel.Create("TAOS", true));
            VOLKSWAGEN.AddVehicleModel(VehicleModel.Create("THE BEETLE", true));
            VOLKSWAGEN.AddVehicleModel(VehicleModel.Create("TIGUAN", true));
            VOLKSWAGEN.AddVehicleModel(VehicleModel.Create("TIGUAN ALLSPACE", true));
            VOLKSWAGEN.AddVehicleModel(VehicleModel.Create("TOUAREG", true));
            VOLKSWAGEN.AddVehicleModel(VehicleModel.Create("UP", true));
            VOLKSWAGEN.AddVehicleModel(VehicleModel.Create("VENTO", true));
            VOLKSWAGEN.AddVehicleModel(VehicleModel.Create("VIRTUS", true));
            VOLKSWAGEN.AddVehicleModel(VehicleModel.Create("VOYAGE", true));
            vehicleFactories.Add(VOLKSWAGEN);

            VehicleFactory ZAMPI = VehicleFactory.Create("ZAMPI");
            vehicleFactories.Add(ZAMPI);

            foreach (var vehicleFactory in vehicleFactories)
            {
                migrationBuilder.InsertData("VehicleFactories", columns: ["Id", "Name"], [vehicleFactory.Id.Value, vehicleFactory.Name]);
                foreach (var vehicleModel in vehicleFactory.Models)
                {
                    migrationBuilder.InsertData("VehicleModels", columns: ["Id", "Name", "VehicleFactoryId", "IsLight"], [vehicleModel.Id.Value, vehicleModel.Name, vehicleFactory.Id.Value, vehicleModel.IsLight]);
                }
            }
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
