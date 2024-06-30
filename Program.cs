class Program
{
      static void Main() {
        double[][] features =  [
            [ 1.0, 2.0 ],
            [ 2.0, 3.0 ],
            [ 3.0, 3.0 ],
            [ 6.0, 5.0 ],
            [ 7.0, 7.0 ],
            [ 8.0, 7.0 ]
        ];
        int[] labels = [ 0, 0, 0, 1, 1, 1 ];

        KNN knn = new KNN(3);
        knn.Train(features, labels);

        double[] newPoint = [ 2.0, 1.0 ];
        int predictedClass = knn.Predict(newPoint);

        Console.WriteLine($"Predicted class for the new data point [{string.Join(", ", newPoint)}]: {predictedClass}");
    }
}
