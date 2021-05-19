package work.com;

import android.view.View;
import android.widget.ImageView;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.cardview.widget.CardView;
import androidx.recyclerview.widget.RecyclerView;

import butterknife.BindView;
import butterknife.ButterKnife;

public class ViewHolder extends RecyclerView.ViewHolder {
    @BindView(R.id.cardView)
    CardView cardView;
    @BindView(R.id.station_name)
    TextView station_Name;
    @BindView(R.id.station_icon)
    ImageView station_Icon;

    public ViewHolder(@NonNull View itemView) {
        super(itemView);
        ButterKnife.bind(this, itemView);
    }
}
