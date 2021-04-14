package com.example.mobilelr2;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.TextView;

import static com.example.mobilelr2.MainActivity.countriesList;

public class Information extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_information);;
        TextView textView = findViewById(R.id.messageText);
        Intent intent = getIntent();
        String message = intent.getStringExtra("message");
        if(message.equalsIgnoreCase("россия")){
        message += " другое официальное название — Росси́йская Федера́ция (РФ), — государство в Восточной Европе и Северной Азии." +
                " Территория России в её конституционных границах составляет 17 125 191 км²; население страны " +
                "(в пределах её заявленной территории) составляет 146 171 015 чел. (2021). " +
                "Занимает первое место в мире по территории, шестое — по объёму" +
                " ВВП и девятое — по численности населения";
        }
        if(message.equalsIgnoreCase("аргентина")){
            message += " (исп. Argentina [aɾxenˈtina]), официальное название — Аргенти́нская Респу́блика (исп. República Argentina [reˈpuβlika aɾxenˈtina]) — " +
                    "второе (после Бразилии) по территории и третье (после Бразилии и Колумбии)" +
                    " по населению государство Южной Америки, состоящее из 24 административных единиц — 23 провинций и федерального столичного округа Буэнос-Айрес.";
        }
        if(message.equalsIgnoreCase("германия")){
            message += " (нем. Deutschland [ˈdɔʏt͡ʃlant]), официальное название — Федерати́вная Респу́блика Герма́ния (нем. Bundesrepublik Deutschland), " +
                    "ФРГ (нем. BRD) — государство в Центральной Европе. Площадь территории — 357 408,74 км². " +
                    "Численность населения на 30 сентября 2019 года — 83 149 300 жителей. " +
                    "Занимает 18-е место в мире по численности населения (2-е в Европе) и 62-е в мире по территории (8-е в Европе).";
        }
        if(message.equalsIgnoreCase("чехия")){
            message += " (чеш. Česko, МФА (чешск.): [ˈʧɛskɔ][6], официально — Че́шская Респу́блика (аббревиатура — ЧР); чеш. Česká republika (аббревиатура — ČR), " +
                    "МФА (чешск.): [ˈʧɛskaː ˈrɛpuˌblɪka]) — государство в Центральной Европе. Граничит с Польшей на севере (длина границы — 796 км), " +
                    "Германией — на северо-западе и западе (810 км), " +
                    "Австрией — на юге (466 км) и Словакией — на востоке (252 км)[8]. Общая протяжённость границы — 2324 км. Площадь — 78 866 км².";
        }
        if(message.equalsIgnoreCase("норвегия")){
            message += " (букмол Norge, нюнорск Noreg), официальное название — Короле́вство Норве́гия (букмол Kongeriket Norge, нюнорск Kongeriket Noreg) — " +
                    "государство в Северной Европе, располагающееся в западной части Скандинавского полуострова и на огромном " +
                    "количестве прилегающих мелких островов, " +
                    "а также архипелаге Шпицберген (Свальбард), островах Ян-Майен и Медвежий в Северном Ледовитом океане.";
        }

        textView.setText(message);
    }
}