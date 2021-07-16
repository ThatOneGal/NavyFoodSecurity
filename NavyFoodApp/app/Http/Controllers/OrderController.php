<?php

namespace App\Http\Controllers;

use App\Models\Location;
use App\Models\Order;
use App\Models\Status;
use Illuminate\Http\Request;
use Illuminate\Support\Facades\Auth;

class OrderController extends Controller
{
    /**
     * Display a listing of the resource.
     *
     */
    public function index()
    {
        //

        return view('Order.OrderingForm');


    }

    /**
     * Show the form for creating a new resource.
     *
     */
    public function create()
    {
        //

        $locationList = Location::all();

        return view('Order.OrderingForm', compact('locationList'));

    }



    /**
     * Store a newly created resource in storage.
     *
     * @param \Illuminate\Http\Request $request
     */
    public function store(Request $request)
    {
        //



        $locationList = Location::all();
        $statusList = Status::all();

        $Order = new Order();
        $Order->fill($request->all());
        $Order->CustomerId = Auth::id();

        $Order->StatusId = 1;
        $Order->OrderDate = now();


        $Order->save();
        return view('Order.Show', compact('Order','locationList','statusList'));

    }

    /**
     * Display the specified resource.
     *
     */
    public function show(Order $Order)
    {
        $locationList = Location::all();
        $statusList = Status::all();



        return view('Order.Show', compact('Order', 'locationList', 'statusList'));
    }

    /**
     * Show the form for editing the specified resource.

     */
    public function edit(Order $Order)
    {
        //
        $locationList = Location::all();
        $statusList = Status::all();
        return view('Order.Edit', compact('Order','locationList', 'statusList'));
    }


    /**
     * Update the specified resource in storage.
     *

     */
    public function update(Request $request, Order $Order)
    {

        $Order->fill($request->all());
        $Order->save();
        return redirect(route('order.show', compact('Order')));

    }
/*    public function update(Request $request, $id)
    {
        $Order = Order::find($id);
        if (!$Order) {
            abort(404);
        }
        $Order->fill($request->all());
        $Order->CustomerId = Auth::id();

        $Order->StatusId = 1;
        $Order->OrderDate = now();


        $Order->save();
        $id = $Order->id;
        return redirect(route('orderfunction.show', compact('id')));

        //
    }*/

    /**
     * Remove the specified resource from storage.
     *
     */
    public function destroy(Order $order)
    {
        //

        $order->delete();
        return redirect(route('order.create'));


    }
}
