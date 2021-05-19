package work.com;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Toast;

import androidx.annotation.NonNull;
import androidx.fragment.app.FragmentActivity;
import androidx.recyclerview.widget.RecyclerView;

import java.util.List;

import model.Station;

public class  TabRecyclerAdapter extends RecyclerView.Adapter<ViewHolder> {
    private Context context;
    private List<Station> stationList;

    public TabRecyclerAdapter(Context context, List<Station> stationList) {
        this.context = context;
        this.stationList = stationList;
    }

    @NonNull
    @Override
    public ViewHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        View view = LayoutInflater.from(context)
                .inflate(R.layout.item_station,parent,false);
        return new ViewHolder(view);
    }

    @Override
    public void onBindViewHolder(@NonNull ViewHolder holder, int position) {
        holder.station_Icon.setImageResource(stationList.get(position).getStationIcon());
        holder.station_Name.setText(stationList.get(position).getStationName());
        holder.cardView.setOnClickListener(
                view -> Toast.makeText(context,R.string.item_station_text,Toast.LENGTH_SHORT).show()
        );
    }

    @Override
    public int getItemCount() {
        return stationList.size();
    }
    @Override
    public void onAttachedToRecyclerView(@NonNull RecyclerView recyclerView) {
        super.onAttachedToRecyclerView(recyclerView);
    }
}
