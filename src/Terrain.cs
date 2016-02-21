using System;

namespace spacecadets
{
    class Terrain
    {
        private int nSeed;
        private double[] heightMap = null;
        private Random randomGenerator;
        private int nWidth, nHeight;

        public Terrain()
        {

        }

        public Terrain(int nSeed)
        {
            setSeed(nSeed);
        }

        public void setSeed(int nSeed)
        {
            this.nSeed = nSeed;
            randomGenerator = new Random(nSeed);
        }

        public void generate(int nWidth, int nHeight)
        {
            if (heightMap == null)
                heightMap = new double[nWidth * nHeight];
            this.nWidth = nWidth;
            this.nHeight = nHeight;

            int nSmall = nWidth < nHeight ? nWidth : nHeight;
            int nFeatureSize = nSeed % nSmall;
            for (int y = 0; y < nHeight; y += nFeatureSize)
            {
                for (int x = 0; x < nWidth; x += nFeatureSize)
                {
                    double dRandomNumber = (randomGenerator.NextDouble() * 2) - 1;
                    setSample(x, y, dRandomNumber);
                }
            }

            int nSampleSize = nFeatureSize;
            double dScale = 1.0;

            while (nSampleSize > 1)
            {
                diamondSquare(nSampleSize, dScale);
                nSampleSize /= 2;
                dScale /= 2.0;
            }
        }

        private void diamondSquare(int nStep, double dScale)
        {
            int nHalfStep = nStep / 2;

            for (int y = nHalfStep; y < nHeight + nHalfStep; y += nStep)
            {
                for (int x = nHalfStep; x < nWidth + nHalfStep; x += nStep)
                {
                    sampleSquare(x, y, nStep, (randomGenerator.NextDouble() - 1) * dScale);
                }
            }

            for (int y = 0; y < nHeight; y += nStep)
            {
                for (int x = 0; x < nWidth; x += nStep)
                {
                    sampleDiamond(x + nHalfStep, y, nStep, (randomGenerator.NextDouble() - 1) * dScale);
                    sampleDiamond(x, y + nHalfStep, nStep, (randomGenerator.NextDouble() - 1) * dScale);
                }
            }
        }

        private void sampleSquare(int nX, int nY, int nSize, double dVal)
        {
            int nHalfSize = nSize / 2;

            double dA = sample(nX - nHalfSize, nY - nHalfSize);
            double dB = sample(nX + nHalfSize, nY - nHalfSize);
            double dC = sample(nX - nHalfSize, nY + nHalfSize);
            double dD = sample(nX + nHalfSize, nY + nHalfSize);
            setSample(nX, nY, (dA + dB + dC + dD) / 4.0 + dVal);
        }

        private void sampleDiamond(int nX, int nY, int nSize, double dVal)
        {
            int nHalfSize = nSize / 2;
            
            double dA = sample(nX - nHalfSize, nY);
            double dB = sample(nX + nHalfSize, nY);
            double dC = sample(nX, nY - nHalfSize);
            double dD = sample(nX, nY + nHalfSize);
            setSample(nX, nY, (dA + dB + dC + dD) / 4.0 + dVal);
        }

        public double sample(int nX, int nY)
        {
            if (nX >= nWidth) nX = nWidth - 1;
            if (nX < 0) nX = 0;
            if (nY >= nHeight) nY = nHeight - 1;
            if (nY < 0) nY = 0;

            return heightMap[nX + nY * nWidth];
        }

        private void setSample(int nX, int nY, double dVal)
        {
            if (nX >= nWidth) nX = nWidth - 1;
            if (nX < 0) nX = 0;
            if (nY >= nHeight) nY = nHeight - 1;
            if (nY < 0) nY = 0;
            heightMap[nX + nY * nWidth] = dVal;
        }
    }
}
