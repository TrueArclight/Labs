package work.com;

import android.content.res.TypedArray;
import android.os.Bundle;

import androidx.fragment.app.Fragment;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import java.util.ArrayList;
import java.util.List;

import butterknife.BindArray;
import butterknife.BindView;
import butterknife.ButterKnife;
import model.Station;

public class TabTransportFragment extends Fragment {
    @BindView(R.id.station_list)
    RecyclerView recyclerView;
    @BindArray(R.array.metro_icons)
    TypedArray station_icons;
    @BindArray(R.array.metros)
    String[] stations;

    public TabTransportFragment() {
    }

    // TODO: Rename and change types and number of parameters
    public static TabTransportFragment newInstance() {
        TabTransportFragment fragment = new TabTransportFragment();
        Bundle args = new Bundle();
        fragment.setArguments(args);
        return fragment;
    }

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        View view = inflater.inflate(R.layout.fragment_tab_transport, container, false);
        ButterKnife.bind(this, view);

        List<Station> stationList = new ArrayList<>();
        for (int i = 0; i < stations.length; i++) {
            Station station = new Station(station_icons.getResourceId(i, 1), stations[i]);
            stationList.add(station);
        }
        recyclerView.setHasFixedSize(true);
        LinearLayoutManager linearLayoutManager = new LinearLayoutManager(getActivity());

        recyclerView.setLayoutManager(linearLayoutManager);
        TabRecyclerAdapter tabRecyclerAdapter = new TabRecyclerAdapter(getActivity(), stationList);

        recyclerView.setAdapter(tabRecyclerAdapter);
        return view;
    }
}