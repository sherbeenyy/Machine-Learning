public class KNN {
    private int K;
    private List<Tuple<double[], int>> trainingData;

    public KNN(int K) {
        this.K = K;
        trainingData = new List<Tuple<double[], int>>();
    }

    public void Train(double[][] features, int[] labels) {
        if (features.Length != labels.Length) {
            throw new ArgumentException("Features and labels arrays must have the same length.");
        }

        for (int i = 0; i < features.Length; i++) {
            trainingData.Add(new Tuple<double[], int>(features[i], labels[i]));
        }
    }

    public int Predict(double[] feature) {
        var distances = trainingData.Select(t => 
            new {
                Distance = EuclideanDistance(t.Item1, feature),
                Label = t.Item2
            }).ToList();

        var nearestNeighbors = distances.OrderBy(t => t.Distance).Take(K);

        var mostCommonLabel = nearestNeighbors
            .GroupBy(n => n.Label)
            .OrderByDescending(g => g.Count())
            .First().Key;

        return mostCommonLabel;
    }

    private double EuclideanDistance(double[] a, double[] b) {
        if (a.Length != b.Length) {
            throw new ArgumentException("Feature vectors must have the same dimension.");
        }

        double sum = 0;
        for (int i = 0; i < a.Length; i++) {
            sum += Math.Pow(a[i] - b[i], 2);
        }
        return Math.Sqrt(sum);
    }
}