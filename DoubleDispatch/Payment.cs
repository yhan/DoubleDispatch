namespace DoubleDispatch
{
    public class Client
    {
        protected int _capital;

        protected Client()
        {
        }

        public int Capital => this._capital;

        public virtual string Name => "Unkown client";

        public virtual void IncrementCapital()
        {
        }
    }

    public class Microsoft : Client
    {
        public Microsoft()
        {
        }

        public override string Name => "Microsoft";

        public override void IncrementCapital()
        {
            this._capital += 10000;
        }
    }

    class Payment
    {
        public virtual string Pay(Microsoft microsoft)
        {
            return $"Pays unknown Microsoft with unknown way";
        }

        public virtual string Pay(Client client)
        {
            return $"Pays unknown client with unknown way";
        }
    }

    class AliPay : Payment
    {
        public override string Pay(Microsoft microsoft)
        {
            microsoft.IncrementCapital();
            return $"Pays {microsoft.Name} through Alibaba";
        }

        public override string Pay(Client client)
        {
            //client.IncrementCapital(); => for Client type, we don't increment capital
            return $"Pays {client.Name} through Alibaba";
        }
    }
}