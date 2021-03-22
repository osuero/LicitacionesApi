using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System.Linq;
using A = DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml;
using DW = DocumentFormat.OpenXml.Drawing.Wordprocessing;
using PIC = DocumentFormat.OpenXml.Drawing.Pictures;
using System.IO;
using Paragraph = DocumentFormat.OpenXml.Wordprocessing.Paragraph;
using Run = DocumentFormat.OpenXml.Wordprocessing.Run;

namespace Licitaciones.Helper
{
    public class Gestor
    {
        string fileName = @"C:\Users\DesarrolloSOS\Pictures\ds.png";

        public void Modificar(string ruta, string carpeta, string nombreArchivo)
        {
                using (WordprocessingDocument documentoWord = WordprocessingDocument.Open(ruta, true))
                {
                    MainDocumentPart partePrincipal = documentoWord.MainDocumentPart;

                    ImagenHeader(fileName, partePrincipal, documentoWord);
                    
                    ImagePart imagePart = partePrincipal.AddImagePart(ImagePartType.Jpeg);
                    
                }
        }

        private void ImagenHeader(string imgRuta, MainDocumentPart documento, WordprocessingDocument documentoWord)
        {
            if (!documento.HeaderParts.Any())
            {
                documento.DeleteParts(documento.HeaderParts);
                var newHeaderPart = documento.AddNewPart<HeaderPart>();

                var imgPart = newHeaderPart.AddImagePart(ImagePartType.Jpeg, "rId999");
                var imagePartID = newHeaderPart.GetIdOfPart(imgPart);

                using (FileStream fs = new FileStream(fileName, FileMode.Open))
                {
                    imgPart.FeedData(fs);
                }
                var rId = documento.GetIdOfPart(newHeaderPart);
                var headerRef = new HeaderReference { Id = rId };
                var sectionProps = documentoWord.MainDocumentPart.Document.Body.Elements<SectionProperties>().LastOrDefault();
                if (sectionProps == null)
                {
                    sectionProps = new SectionProperties();
                    documentoWord.MainDocumentPart.Document.Body.Append(sectionProps);
                }
                sectionProps.RemoveAllChildren<HeaderReference>();
                sectionProps.Append(headerRef);
                newHeaderPart.Header = GenerarImagenHeaeder(imagePartID);
                newHeaderPart.Header.Save();
            }
        }
        private static Header GenerarImagenHeaeder(string relationshipId)
        {
            var element =
                new Drawing(
                    new DW.Inline(
                        new DW.Extent() { Cx = 990000L, Cy = 792000L },
                        new DW.EffectExtent()
                        {
                            LeftEdge = 0L,
                            TopEdge = 0L,
                            RightEdge = 0L,
                            BottomEdge = 0L
                        },
                        new DW.DocProperties()
                        {
                            Id = (UInt32Value)1U,
                            Name = "institucionLogo"
                        },
                        new DW.NonVisualGraphicFrameDrawingProperties(
                            new A.GraphicFrameLocks() { NoChangeAspect = true }),
                        new A.Graphic(
                            new A.GraphicData(
                                new PIC.Picture(
                                    new PIC.NonVisualPictureProperties(
                                        new PIC.NonVisualDrawingProperties()
                                        {
                                            Id = (UInt32Value)0U,
                                            Name = "institucionLogo.png"
                                        },
                                        new PIC.NonVisualPictureDrawingProperties()),
                                    new PIC.BlipFill(
                                        new A.Blip(
                                            new A.BlipExtensionList(
                                                new A.BlipExtension()
                                                {
                                                    Uri =
                                                        "{28A0092B-C50C-407E-A947-70E740481C1C}"
                                                })
                                        )
                                        {
                                            Embed = relationshipId,
                                            CompressionState =
                                                A.BlipCompressionValues.Print
                                        },
                                        new A.Stretch(
                                            new A.FillRectangle())),
                                    new PIC.ShapeProperties(
                                        new A.Transform2D(
                                            new A.Offset() { X = 0L, Y = 0L },
                                            new A.Extents() { Cx = 990000L, Cy = 792000L }),
                                        new A.PresetGeometry(
                                            new A.AdjustValueList()
                                        )
                                        { Preset = A.ShapeTypeValues.Rectangle }))
                            )
                            { Uri = "http://schemas.openxmlformats.org/drawingml/2006/picture" })
                    )
                    {
                        DistanceFromTop = (UInt32Value)0U,
                        DistanceFromBottom = (UInt32Value)0U,
                        DistanceFromLeft = (UInt32Value)8U,
                        DistanceFromRight = (UInt32Value)0U,
                        EditId = "50D07946"
                    });

            var header = new Header();
            var paragraph = new Paragraph();
            var run = new Run();

            run.Append(element);
            paragraph.Append(run);
            header.Append(paragraph);
            return header;
        }
        private static void AgregarImagenAlCuerpo(WordprocessingDocument wordDoc, string relationshipId)
        {
            var element =
                 new Drawing(
                     new DW.Inline(
                         new DW.Extent() { Cx = 490000L, Cy = 292000L },
                         new DW.EffectExtent()
                         {
                             LeftEdge = 0L,
                             TopEdge = 292000L,
                             RightEdge = 0L,
                             BottomEdge = 0L
                         },
                         new DW.DocProperties()
                         {
                             Id = (UInt32Value)1U,
                             Name = "institucionLogo"
                         },
                         new DW.NonVisualGraphicFrameDrawingProperties(
                             new A.GraphicFrameLocks() { NoChangeAspect = true }),
                         new A.Graphic(
                             new A.GraphicData(
                                 new PIC.Picture(
                                     new PIC.NonVisualPictureProperties(
                                         new PIC.NonVisualDrawingProperties()
                                         {
                                             Id = (UInt32Value)0U,
                                             Name = "institucionLogo.jpg"
                                         },
                                         new PIC.NonVisualPictureDrawingProperties()),
                                     new PIC.BlipFill(
                                         new A.Blip(
                                             new A.BlipExtensionList(
                                                 new A.BlipExtension()
                                                 {
                                                     Uri =
                                                        "{28A0092B-C50C-407E-A947-70E740481C1C}"
                                                 })
                                         )
                                         {
                                             Embed = relationshipId,
                                             CompressionState =
                                             A.BlipCompressionValues.Print
                                         },
                                         new A.Stretch(
                                             new A.FillRectangle())),
                                     new PIC.ShapeProperties(
                                         new A.Transform2D(
                                             new A.Offset() { X = 0L, Y = 0L },
                                             new A.Extents() { Cx = 990000L, Cy = 792000L }),
                                         new A.PresetGeometry(
                                             new A.AdjustValueList()
                                         )
                                         { Preset = A.ShapeTypeValues.Rectangle }))
                             )
                             { Uri = "http://schemas.openxmlformats.org/drawingml/2006/picture" })
                     )
                     {
                         DistanceFromTop = (UInt32Value)0U,
                         DistanceFromBottom = (UInt32Value)0U,
                         DistanceFromLeft = (UInt32Value)0U,
                         DistanceFromRight = (UInt32Value)0U,
                         EditId = "50D07946"
                     });
        }
    }
}
