using System.Collections;
using System.Collections.Generic;

public interface IPurchasingCapable {
    void Buy(Item item);
}

public interface ISellCapable {
    void Sell(Item item);
}
