namespace FastTechFoods.Worker.Infra.Mensageria.Consumer
{
    public interface IConsumer
    {
        void StartConsuming(CancellationToken cancellationToken);
    }
}