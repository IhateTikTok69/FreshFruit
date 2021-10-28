using FreshFruit.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreshFruit.controller
{
    class BucketController
    {
        private Bucket bucket;
        private BucketEventListener eventListener;
        private Bucket keranjangBuah;
        private MainWindow mainWindow;

        public BucketController(Bucket keranjangBuah, MainWindow mainWindow)
        {
            this.keranjangBuah = keranjangBuah;
            this.mainWindow = mainWindow;
        }

        public void addFruit(Fruit fruit)
        {
            if (bucketIsOverloaded())
            {
                eventListener.onfailed("oops, keranjang penuh");
            }
            else
            {
                this.bucket.insert(fruit);
                eventListener.onSucceed("Yay, Berhasil ditambahkan");
            }
        }

        internal List<Fruit> findAll()
        {
            throw new NotImplementedException();
        }

        public bool bucketIsOverloaded()
        {
            return bucket.countItems() >= bucket.getCapacity();
        }
        public void removeFruit(Fruit fruit)
        {
            for (int itemPostition = 0; itemPostition < bucket.countItems(); itemPostition++)
            {
                bucket.remove(itemPostition);
                eventListener.onSucceed("yey, berhasil dihapus");
            }
        }
    }
}
