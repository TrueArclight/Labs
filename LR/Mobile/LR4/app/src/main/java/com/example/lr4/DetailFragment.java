package com.example.lr4;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageView;
import android.widget.TextView;
import androidx.fragment.app.Fragment;

public class DetailFragment extends Fragment {

    String ru = "\nСтолица: Москва\nКарта:\n",
            ge = "\nСтолица: Берлин\nКарта:\n",
            czh = " \nСтолица: Прага\nКарта:\n",
            nor = " \nСтолица: Осло\nКарта:\n",
            ag =" \nСтолица: Буэнос Айрес\nКарта:\n";

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
        return inflater.inflate(R.layout.fragment_detail, container, false);
    }

    public void setSelectedItem(String selectedItem) {
        ImageView imageView = (ImageView) getView().findViewById(R.id.map);
        TextView view = (TextView) getView().findViewById(R.id.detailsText);
        if(selectedItem.equalsIgnoreCase("россия")) {
            view.setText(selectedItem += ru);
            imageView.setImageResource(R.drawable.russia);
        }
        if(selectedItem.equalsIgnoreCase("аргентина")){
            view.setText(selectedItem += ag);
            imageView.setImageResource(R.drawable.argentina);
        }
        if(selectedItem.equalsIgnoreCase("германия")){
            view.setText(selectedItem += ge);
            imageView.setImageResource(R.drawable.germany);
        }
        if(selectedItem.equalsIgnoreCase("чехия")){
            view.setText(selectedItem += czh );
            imageView.setImageResource(R.drawable.czech);
        }
        if(selectedItem.equalsIgnoreCase("норвегия")){
            view.setText(selectedItem  += nor);
            imageView.setImageResource(R.drawable.norway);
        }
    }
}