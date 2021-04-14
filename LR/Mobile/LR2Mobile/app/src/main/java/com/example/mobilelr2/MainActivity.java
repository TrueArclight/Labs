package com.example.mobilelr2;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Adapter;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.ListView;
import android.widget.TextView;

import java.util.ArrayList;

public class MainActivity extends AppCompatActivity {
    ArrayList<State> states = new ArrayList();
    public static ListView countriesList;
    String[] countries = { "Россия", "Аргентина", "Германия", "Чехия", "Норвегия"};
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        setInitialData();
        countriesList = (ListView) findViewById(R.id.countriesList);
        StateAdapter stateAdapter = new StateAdapter(this, R.layout.list_item, states);
        countriesList.setAdapter(stateAdapter);
        Intent intent = new Intent(this, Information.class);
        AdapterView.OnItemClickListener itemListener = new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> parent, View v, int position, long id) {

                String selectedItem = countries[position];
                intent.putExtra("message", selectedItem);
                startActivity(intent);
            }
        };
        countriesList.setOnItemClickListener(itemListener);
    }
    private void setInitialData(){

        states.add(new State ("Россия", "Москва", R.drawable.russia));
        states.add(new State ("Аргентина", "Буэнос-Айрес", R.drawable.argentina));
        states.add(new State ("Германия", "Берлин", R.drawable.germany));
        states.add(new State ("Чехия", "Прага", R.drawable.czech));
        states.add(new State ("Норвегия", "Осло", R.drawable.norway));

    }
}