namespace ProjectR.Classes
{
    public class GraphData<T>(T xSeries, int value)
    {
        public T XSeries { get; set; } = xSeries;

        public double Value { get; set; } = value;
    }
}
