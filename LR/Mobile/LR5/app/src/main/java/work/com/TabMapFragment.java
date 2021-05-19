package work.com;

import android.os.Bundle;

import androidx.annotation.NonNull;
import androidx.fragment.app.Fragment;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import com.google.android.gms.maps.CameraUpdate;
import com.google.android.gms.maps.CameraUpdateFactory;
import com.google.android.gms.maps.GoogleMap;
import com.google.android.gms.maps.OnMapReadyCallback;
import com.google.android.gms.maps.SupportMapFragment;
import com.google.android.gms.maps.model.LatLng;
import com.google.android.gms.maps.model.MarkerOptions;

public class TabMapFragment extends Fragment {


    public TabMapFragment() {
        // Required empty public constructor
    }
    public static TabMapFragment newInstance() {
        TabMapFragment fragment = new TabMapFragment();
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
        // Inflate the layout for this fragment
        View view = inflater.inflate(R.layout.fragment_tab_map, container, false);
        SupportMapFragment supportMapFragment = (SupportMapFragment)getChildFragmentManager().findFragmentById(R.id.google_map);
        supportMapFragment.getMapAsync(new OnMapReadyCallback() {
            @Override
            public void onMapReady(@NonNull GoogleMap googleMap) {
                GoogleMap hMap = googleMap;
                LatLng latLng = new LatLng(51.507351,-0.127758);
                hMap.addMarker(new MarkerOptions().position(latLng).title("Welcome to London"));
                hMap.animateCamera(CameraUpdateFactory.newLatLngZoom(latLng,10),1000,null);
                googleMap.setOnMapClickListener(new GoogleMap.OnMapClickListener() {
                    @Override
                    public void onMapClick(@NonNull LatLng latLng) {
                        MarkerOptions markerOptions = new MarkerOptions();
                        markerOptions.position(latLng);
                        //hMap.clear();
                        hMap.animateCamera(CameraUpdateFactory.newLatLngZoom(latLng,10));
                        //hMap.addMarker(markerOptions);
                    }
                });
            }
        });
        return view;
    }
}