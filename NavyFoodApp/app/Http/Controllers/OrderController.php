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
        $Order->CustomerId = Auth::id($this);

        $Order->StatusId = 1;
        $Order->OrderDate = now();


        $Order->save();
        return view('Order.OrderingIndex', compact('Order','locationList','statusList'));

    }

    /**
     * Display the specified resource.
     *
     */
    public function show()
    {
        //
        return view('Order.OrderingIndex');
    }

    /**
     * Show the form for editing the specified resource.
     *
     * @param \App\Models\OrderContent $orderContent
     * @return \Illuminate\Http\Response
     */
    public function edit(Order $order)
    {
        //
    }

    /**
     * Update the specified resource in storage.
     *
     * @param \Illuminate\Http\Request $request
     * @param \App\Models\OrderContent $orderContent
     * @return \Illuminate\Http\Response
     */
    public function update(Request $request, Order $order)
    {
        //
    }

    /**
     * Remove the specified resource from storage.
     *
     * @param \App\Models\OrderContent $orderContent
     * @return \Illuminate\Http\Response
     */
    public function destroy(Order $order)
    {
        //

    }
}
