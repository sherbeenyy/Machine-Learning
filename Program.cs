class Program
{
      static void Main(string[] args) {
        double[][] features =  [
            [ 1.0, 2.0 ],
            [ 2.0, 3.0 ],
            [ 3.0, 3.0 ],
            [ 6.0, 5.0 ],
            [ 7.0, 7.0 ],
            [ 8.0, 7.0 ]
        ];
        int[] labels = [ 0, 0, 0, 1, 1, 1 ]; 

        // Initialize KNN with K=3
        KNN knn = new KNN(3);
        knn.Train(features, labels);

        // Predict the class of a new data point
        double[] newPoint = [ 5.0, 5.0 ];
        int predictedClass = knn.Predict(newPoint);

        Console.WriteLine($"Predicted class for the new data point [{string.Join(", ", newPoint)}]: {predictedClass}");
    }
}
