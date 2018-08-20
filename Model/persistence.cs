using System.Collections.Generic;

public class persistence
{
    public List<store> stores { get; set; }

    public List<article> articles{ get; set; }

    public void seed(){
      stores = new List<store>();
      articles = new List<article>();

      stores.Add(new store{
        id= 1,
        address="Somewhere over the rainbow",
        name="super store"
      });

      stores.Add(new store{
        id= 2,
        address="calle 2",
        name="mini store"
      });

      articles.Add(new article{
        id= 1,
        description="The best quality of shoes in a green color",
        name="green shoes",
        price= 20.15,
        total_in_shelf=25,
        total_in_vault=10,
        store = stores[0],
      });

      articles.Add(new article{
        id= 1,
        description="desc1",
        name="article 1",
        price= 20.15,
        total_in_shelf=25,
        total_in_vault=10,
        store = stores[1],
      });
    }
}