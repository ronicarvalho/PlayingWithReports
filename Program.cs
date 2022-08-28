using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using QuestPDF.Previewer;

Document.Create(document =>
{
    document.Page(page =>
    {
        page.Size(PageSizes.A4);
        page.Margin(1.5f, Unit.Centimetre);
        page.PageColor(Colors.White);
        page.DefaultTextStyle(f => f.FontSize(9));

        page.Header()
            .Row(row =>
            {
                row.RelativeItem(2)
                    .AlignLeft()
                    .Element(ItemStyle)
                    .Text("Nº total de viaturas no acidente: ________");

                row.RelativeItem(1)
                    .Element(ItemStyle)
                    .Text("Data: ___/___/______");

                row.RelativeItem(1)
                    .Element(ItemStyle)
                    .Text("Folha 1/______");

                static IContainer ItemStyle(IContainer container) => container
                    .AlignRight()
                    .Border(1)
                    .Padding(2.5f);
            });

        page.Content()
            .Column(column =>
            {
                column.Item()
                    .PaddingVertical(15)
                    .Table(table =>
                    {
                        table.ColumnsDefinition(columns =>
                        {
                            columns.ConstantColumn(20);
                            columns.RelativeColumn();
                            columns.ConstantColumn(220);
                            columns.RelativeColumn();
                        });

                        table.Cell().Element(CellStyle).Text("");
                        table.Cell().Element(CellStyle).Text("Secção Corrente");
                        table.Cell().Row(row =>
                        {
                            row.RelativeItem().Element(CellStyle).Text("AE / IP / IC / EN: _______");
                            row.ConstantItem(1).LineVertical(1);
                            row.RelativeItem().Element(CellStyle).Text("KM: ________ + ________");
                        });
                        table.Cell().Element(CellStyle).Text("Sentido: _____________________");

                        table.Cell().Element(CellStyle).Text("");
                        table.Cell().Element(CellStyle).Text("Portagem");
                        table.Cell().Element(CellStyle).Text("");
                        table.Cell().Element(CellStyle).Text("Via nº: _______________________");

                        table.Cell().Element(CellStyle).Text("");
                        table.Cell().Element(CellStyle).Text("Nó");
                        table.Cell().Element(CellStyle).Text("");
                        table.Cell().Element(CellStyle).Text("Ramo: _______________________");

                        table.Cell().Element(CellStyle).Text("");
                        table.Cell().Element(CellStyle).Text("Acesso rede exterior");
                        table.Cell().Element(CellStyle).Text("");
                        table.Cell().Element(CellStyle).Text("Sentido: _____________________");

                        table.Cell().Element(CellStyle).Text("");
                        table.Cell().Element(CellStyle).Text("Área de Serviço / Repouso");
                        table.Cell().Element(CellStyle).Text("");
                        table.Cell().Element(CellStyle).Text("Sentido: _____________________");

                        static IContainer CellStyle(IContainer container) => container
                            .Border(1)
                            .PaddingLeft(5)
                            .BorderColor(Colors.Black)
                            .PaddingVertical(2);
                    });

                column.Item()
                    .Table(table =>
                    {
                        table.ColumnsDefinition(columns =>
                        {
                            columns.RelativeColumn();
                            columns.ConstantColumn(40);
                            columns.RelativeColumn();
                            columns.ConstantColumn(40);
                            columns.RelativeColumn();
                            columns.ConstantColumn(40);
                            columns.RelativeColumn();
                            columns.ConstantColumn(40);
                        });

                        table.Header(header =>
                        {
                            header.Cell().ColumnSpan(8).Element(HeaderStyle).Row(row =>
                                row.RelativeItem().Element(TextStyle).Text("Actividades AR"));

                            static IContainer TextStyle(IContainer container) => container
                                .DefaultTextStyle(ts => ts.ExtraBold())
                                .PaddingVertical(2)
                                .AlignCenter();

                            static IContainer HeaderStyle(IContainer container) => container
                                .Border(1)
                                .BorderColor(Colors.Black);
                        });

                        table.Cell().Element(CellStyle).Text("Hora Comunicação");
                        table.Cell().Element(CenteredCellStyle).Text(":");
                        table.Cell().Element(CellStyle).Text("Origem Participação");
                        table.Cell().Element(CenteredCellStyle).Text("");
                        table.Cell().Element(CellStyle).Text("Hora Acidente");
                        table.Cell().Element(CenteredCellStyle).Text(":");
                        table.Cell().Element(CellStyle).Text("Chegada Local (AR)");
                        table.Cell().Element(CenteredCellStyle).Text(":");

                        table.Cell().Element(CellStyle).Text("Situação Normal às");
                        table.Cell().Element(CenteredCellStyle).Text(":");
                        table.Cell().ColumnSpan(6).Element(CellStyle).Text("Obs");

                        static IContainer CellStyle(IContainer container) => container
                            .Border(1)
                            .PaddingLeft(5)
                            .BorderColor(Colors.Black)
                            .PaddingVertical(2);

                        static IContainer CenteredCellStyle(IContainer container) => container
                            .Border(1)
                            .BorderColor(Colors.Black)
                            .AlignCenter();
                    });

                column.Item().Table(table =>
                {
                    table.ColumnsDefinition(columns =>
                    {
                        columns.ConstantColumn(90);
                        columns.ConstantColumn(70);
                        columns.RelativeColumn();
                        columns.RelativeColumn();
                    });

                    table.Header(header =>
                    {
                        header.Cell().ColumnSpan(4).Element(HeaderStyle).Row(row =>
                            row.RelativeItem().Element(TextStyle).Text("Meios externos à Brisa"));

                        static IContainer TextStyle(IContainer container) => container
                            .DefaultTextStyle(ts => ts.ExtraBold())
                            .PaddingVertical(2)
                            .AlignCenter();

                        static IContainer HeaderStyle(IContainer container) => container
                            .Border(1)
                            .BorderColor(Colors.Black);
                    });

                    table.Cell().Element(CenteredCellStyle).Text("");
                    table.Cell().Element(CenteredCellStyle).Text("Hora Chegada");
                    table.Cell().Element(CenteredCellStyle).Text("Nome / Destacamento / Corporação");
                    table.Cell().Element(CenteredCellStyle).Text("Actividades Efectuadas");

                    table.Cell().Element(CellStyle).Text("GNR / PS");
                    table.Cell().Element(CenteredCellStyle).Text(":");
                    table.Cell().Element(CellStyle).Text("");
                    table.Cell().Element(CellStyle).Text("");

                    table.Cell().Element(CellStyle).Text("Ambulância");
                    table.Cell().Element(CenteredCellStyle).Text(":");
                    table.Cell().Element(CellStyle).Text("");
                    table.Cell().Element(CellStyle).Text("");

                    table.Cell().Element(CellStyle).Text("=");
                    table.Cell().Element(CenteredCellStyle).Text(":");
                    table.Cell().Element(CellStyle).Text("");
                    table.Cell().Element(CellStyle).Text("");

                    table.Cell().Element(CellStyle).Text("Bombeiros");
                    table.Cell().Element(CenteredCellStyle).Text(":");
                    table.Cell().Element(CellStyle).Text("");
                    table.Cell().Element(CellStyle).Text("");

                    table.Cell().Element(CellStyle).Text("=");
                    table.Cell().Element(CenteredCellStyle).Text(":");
                    table.Cell().Element(CellStyle).Text("");
                    table.Cell().Element(CellStyle).Text("");

                    table.Cell().Element(CellStyle).Text("BCI");
                    table.Cell().Element(CenteredCellStyle).Text(":");
                    table.Cell().Element(CellStyle).Text("");
                    table.Cell().Element(CellStyle).Text("");

                    table.Cell().Element(CellStyle).Text("Outros");
                    table.Cell().Element(CenteredCellStyle).Text(":");
                    table.Cell().Element(CellStyle).Text("");
                    table.Cell().Element(CellStyle).Text("");

                    table.Cell().Element(CellStyle).Text("");
                    table.Cell().Element(CenteredCellStyle).Text(":");
                    table.Cell().Element(CellStyle).Text("");
                    table.Cell().Element(CellStyle).Text("");

                    table.Cell().Element(CellStyle).Text("");
                    table.Cell().Element(CenteredCellStyle).Text(":");
                    table.Cell().Element(CellStyle).Text("");
                    table.Cell().Element(CellStyle).Text("");

                    static IContainer CellStyle(IContainer container) => container
                        .Border(1)
                        .PaddingLeft(5)
                        .BorderColor(Colors.Black)
                        .PaddingVertical(2);

                    static IContainer CenteredCellStyle(IContainer container) => container
                        .Border(1)
                        .BorderColor(Colors.Black)
                        .AlignCenter()
                        .DefaultTextStyle(ts => ts.ExtraBold());
                });

                column.Item()
                    .PaddingVertical(15)
                    .BorderTop(1)
                    .BorderBottom(1)
                    .BorderColor(Colors.Black)
                    .Table(table =>
                    {
                        table.ColumnsDefinition(columns =>
                        {
                            columns.RelativeColumn();
                            columns.RelativeColumn();
                            columns.RelativeColumn();
                            columns.RelativeColumn();
                        });
                        
                        table.Header(header =>
                        {
                            header.Cell().Row(row =>
                                row.RelativeItem().Element(TextStyle).Text("Identificação do aciente"));
                            
                            header.Cell().Row(row =>
                                row.RelativeItem().Element(TextStyle).Text("Circunstancias externas"));
                            
                            header.Cell().Row(row =>
                                row.RelativeItem().Element(TextStyle).Text("6. Natureza do aciente"));
                            
                            header.Cell().Row(row =>
                                row.RelativeItem().Element(TextStyle).Text("7. Causas prováveis do aciente"));

                            static IContainer TextStyle(IContainer container) => container
                                .DefaultTextStyle(ts => ts.ExtraBold())
                                .PaddingVertical(2)
                                .AlignCenter();
                        });
                        
                        table.Cell().Element(CellStyle).Column(column1 =>
                        {
                            column1.Item().Text("1. Via");
                            column1.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Berma direita");
                            });
                            column1.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Lentos");
                            });
                            column1.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Direita");
                            });
                            column1.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Central Direita");
                            });
                            column1.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Central");
                            });
                            column1.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Central Esquerda");
                            });
                            column1.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Esquerda");
                            });
                            column1.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Berma Esquerda");
                            });
                            column1.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Única");
                            });
                            column1.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Abrandamento/acelera");
                            });
                            column1.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Não identificada");
                            });
                            
                            column1.Item().PaddingTop(10).Text("2. Zona");
                            column1.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Secção Corrente");
                            });
                            column1.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Ramo (A, B, C...)");
                            });
                            column1.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Acesso à Portagem");
                            });
                            column1.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Portagem Via Verde");
                            });
                            column1.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Portagem Via Manual");
                            });
                            column1.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Portagem Zona Garrafão");
                            });
                            column1.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Acesso exterior");
                            });
                            column1.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Área de serviço / repouso");
                            });
                            column1.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Obtas: ____________");
                            });
                            column1.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Tuneis");
                            });
                            column1.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Outra: ____________");
                            });
                            column1.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Não identificada");
                            });
                        });
                        
                        table.Cell().Element(CellStyle).Column(column2 =>
                        {
                            column2.Item().Text("3. Factores atmosféricos");
                            column2.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Bom tempo");
                            });
                            column2.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Chuva");
                            });
                            column2.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Vento forte");
                            });
                            column2.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Chuva e vento forte");
                            });
                            column2.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Nevoeiro");
                            });
                            column2.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Granizo");
                            });
                            column2.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Neve");
                            });
                            
                            
                            column2.Item().PaddingTop(10).Text("4. Luminosidade");
                            column2.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Pleno dia");
                            });
                            column2.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Crepúsculo / Aurora");
                            });
                            column2.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Noite escura");
                            });
                            column2.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Noite com luar");
                            });
                            column2.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Zona com iluminação");
                            });
                            
                            
                            column2.Item().PaddingTop(10).Text("5. Estado do piso");
                            column2.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Seco e limpo");
                            });
                            column2.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Molhado");
                            });
                            column2.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Gelo / Geada / Neve");
                            });
                            column2.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Gravilha / Areia");
                            });
                            column2.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Óleo / Gordura");
                            });
                            column2.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Outro: ____________");
                            });
                        });
                        
                        table.Cell().Element(CellStyle).Column(column3 =>
                        {
                            column3.Item().Text("Colisão entre veículos");
                            column3.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Traseira");
                            });
                            column3.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Lateral");
                            });
                            column3.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Frontal");
                            });
                            column3.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Choque em cadeia");
                            });
                            
                            
                            column3.Item().PaddingTop(10).Text("Colisão com infraestrutura");
                            column3.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Guardas seg. dta.");
                            });
                            column3.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Guardas seg. esq.");
                            });
                            column3.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Guardas seg. esq. transposição");
                            });
                            column3.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Perfil betão dir.");
                            });
                            column3.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Perfil betão esq.");
                            });
                            column3.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Perfil betão esq. transposição");
                            });
                            column3.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Talude");
                            });
                            column3.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Sinalização");
                            });
                            
                            column3.Item().PaddingTop(10).Text("Outras Colisões");
                            column3.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Animal");
                            });
                            column3.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Peão");
                            });
                            column3.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Obj/Obst");
                            });
                            column3.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Projecção");
                            });
                            column3.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Veiculo parado na berma");
                            });
                            
                            
                            column3.Item().PaddingTop(10).Text("Outra Natureza");
                            column3.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Despiste");
                            });
                            column3.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Capotamento");
                            });
                            column3.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Arremesso");
                            });
                            column3.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Outros: ____________");
                            });
                        });
                        
                        table.Cell().Element(CellStyle).Column(column4 =>
                        {
                            column4.Item().Text("Factores humanos");
                            column4.Item().Text("1. Via");
                            column4.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Sonolencia Adormecimento");
                            });
                            column4.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Sob efeito de alcool");
                            });
                            column4.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Doença subita");
                            });
                            column4.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Distração");
                            });
                            column4.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Incumprimento sinalização");
                            });
                            column4.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Velocidade excessiva");
                            });
                            column4.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Excesso de velocidade");
                            });
                            column4.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Manobra incorrecta");
                            });
                            column4.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Circulação em contramão");
                            });
                            
                            
                            column4.Item().PaddingTop(10).Text("Veículo");
                            column4.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Rebentamento de pneu");
                            });
                            column4.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Avaria mecânica / elétrica");
                            });
                            
                            
                            column4.Item().PaddingTop(10).Text("Envolvente");
                            column4.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Obstaculo na via");
                            });
                            column4.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Deficiencia do piso");
                            });
                            column4.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Gravilha / Areia");
                            });
                            column4.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Óleo gordura");
                            });
                            column4.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Gelo / Geada / Neve");
                            });
                            column4.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Retenção de Agua");
                            });
                            column4.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Outros: __________");
                            });
                            
                            
                            column4.Item().PaddingTop(10).Text("Outras Causas");
                            column4.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Encadeamento");
                            });
                            column4.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Outros: ____________");
                            });
                            column4.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Não identificada");
                            });
                        });

                        static IContainer ItemStyle(IContainer container) => container
                            .PaddingTop(3);
                        
                        static IContainer CellStyle(IContainer container) => container
                            .PaddingLeft(5).PaddingVertical(2);
                        
                        static IContainer BoxStyle(IContainer container) => container
                            .Height(15).Border(1).BorderColor(Colors.Black);
                            
                        static IContainer LabelStyle(IContainer container) => container
                            .PaddingLeft(5);
                    });

                // column.Item()
                //     .PaddingVertical(15)
                //     .BorderTop(1)
                //     .BorderBottom(1)
                //     .BorderColor(Colors.Black)
                //     .Table(table =>
                //     {
                //     });
            });
    });
}).ShowInPreviewer();