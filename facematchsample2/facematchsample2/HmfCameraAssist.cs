using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenCvSharp;

namespace facematchsample2
{
    class HmfCameraAssist
    {
        public static IplImage FaceDe(IplImage src) {
            CvColor[] colors = new CvColor[]{
                new CvColor(0,0,255),
                new CvColor(0,128,255),
                new CvColor(0,255,255),
                new CvColor(0,255,0),
                new CvColor(255,128,0),
                new CvColor(255,255,0),
                new CvColor(255,0,0),
                new CvColor(255,0,255),
            };


            const double Scale = 1.04;
            const double ScaleFactor = 1.139;
            const int MinNeighbors = 2;
            //CvArr waraiotoko = Cv.LoadImage("j");
            IplImage warai = Cv.LoadImage("C:\\Users\\tamago\\Documents\\Visual Studio 2010\\project\\facematch_sample\\facematch_sample\\warai_flat.png");

            using (IplImage smallImg = new IplImage(new CvSize(Cv.Round(src.Width / Scale), Cv.Round(src.Height / Scale)), BitDepth.U8, 1))
            {
                // 顔検出用の画像の生成
                using (IplImage gray = new IplImage(src.Size, BitDepth.U8, 1))
                {
                    Cv.CvtColor(src, gray, ColorConversion.BgrToGray);
                    Cv.Resize(gray, smallImg, Interpolation.Linear);
                    Cv.EqualizeHist(smallImg, smallImg);
                }

                //using (CvHaarClassifierCascade cascade = Cv.Load<CvHaarClassifierCascade>(Const.XmlHaarcascade))  // どっちでも可
                using (CvHaarClassifierCascade cascade = CvHaarClassifierCascade.FromFile("C:\\Users\\tamago\\Documents\\Visual Studio 2010\\project\\facematch_sample\\facematch_sample\\haarcascade_frontalface_alt.xml"))
                using (CvMemStorage storage = new CvMemStorage())
                {
                    storage.Clear();

                    // 顔の検出
                    CvSeq<CvAvgComp> faces = Cv.HaarDetectObjects(smallImg, cascade, storage, ScaleFactor, MinNeighbors, 0, new CvSize(30, 30));

                    // モザイク処理
                    for (int d = 0; d < faces.Total; d++)
                    {
                        CvRect r = faces[d].Value.Rect;
                        CvSize size = new CvSize(r.Width + 30, r.Height + 30);
                        using (IplImage img_laugh_resized = new IplImage(size, warai.Depth, warai.NChannels))
                        {
                            Cv.Resize(warai, img_laugh_resized, Interpolation.NearestNeighbor);

                            int i_max = (((r.X + img_laugh_resized.Width) > src.Width) ? src.Width - r.X : img_laugh_resized.Width);
                            int j_max = (((r.Y + img_laugh_resized.Height) > src.Height) ? src.Height - r.Y : img_laugh_resized.Height);

                            for (int j = 0; j < img_laugh_resized.Width; ++j)
                            {
                                for (int i = 0; i < img_laugh_resized.Height; ++i)
                                {
                                    CvColor color = img_laugh_resized[i, j];
                                    if (img_laugh_resized[i, j].Val1 != 0) src[r.Y + i, r.X + j] = color;//img_laugh_resized[i, j];
                                }
                            }
                        }
                    }
                    return src;
                }
            }
        }
    }
}
