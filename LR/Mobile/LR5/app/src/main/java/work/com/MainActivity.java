package work.com;

import androidx.appcompat.app.AppCompatActivity;
import androidx.appcompat.widget.Toolbar;
import androidx.viewpager.widget.ViewPager;
import android.os.Bundle;
import com.google.android.material.tabs.TabLayout;

public class MainActivity extends AppCompatActivity {
    TabLayout tabLayout;
    ViewPager viewPager;
    Toolbar toolbar;
    final int [] tabIcons = new int[]{
            R.drawable.ic_info_white_24dp,
            R.drawable.ic_transport_white_24dp,
            R.drawable.ic_place_white_24dp,
    };
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        viewPager = findViewById(R.id.view_pager);
        tabLayout = findViewById(R.id.tabs);
        toolbar = findViewById(R.id.toolbar);
        setupViewPager(viewPager);
        tabLayout.setupWithViewPager(viewPager);
        TabLayout.Tab tabInfo = tabLayout.getTabAt(0);
        if (tabInfo != null) tabInfo.setIcon(tabIcons[0]);
        TabLayout.Tab tabTransport = tabLayout.getTabAt(1);
        if (tabTransport != null) tabTransport.setIcon(tabIcons[1]);
        TabLayout.Tab tabPlace = tabLayout.getTabAt(2);
        if (tabPlace != null) tabPlace.setIcon(tabIcons[2]);

    }
    private void setupViewPager(ViewPager viewPager) {
        ViewPagerAdapter pagerAdapter = new ViewPagerAdapter(getSupportFragmentManager());
        pagerAdapter.addFragment(new TabInfoFragment(),"Info");
        pagerAdapter.addFragment(new TabTransportFragment(),"Transport");
        pagerAdapter.addFragment(new TabMapFragment(), "Map");
        viewPager.setAdapter(pagerAdapter);
    }
}