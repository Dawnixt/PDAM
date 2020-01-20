package es.iesnervion.avazquez.pruebapicasso.adapter;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.ImageView;

import com.squareup.picasso.Picasso;

import java.util.ArrayList;

import es.iesnervion.avazquez.pruebapicasso.R;

public class ImageAdapter extends BaseAdapter {

    private ArrayList<String> listaURLs;
    private Context context;

    public ImageAdapter(ArrayList<String> listaURLs, Context context) {
        this.listaURLs = listaURLs;
        this.context = context;
    }

    @Override
    public int getCount() {
        return listaURLs.size();
    }

    @Override
    public Object getItem(int position) {
        return null;
    }

    @Override
    public long getItemId(int position) {
        return 0;
    }

    @Override
    public View getView(int position, View convertView, ViewGroup parent) {
        ImageView img;
        if (null == convertView) {
            convertView = LayoutInflater.from(context).
                    inflate(R.layout.image_row, parent, false);

        }
        img = convertView.findViewById(R.id.foto);
        Picasso
                .get()
                .load(listaURLs.get(position))

                .placeholder(R.drawable.placeholder)
                .error(R.drawable.error)
                .into(img);

        return convertView;
    }
    }

