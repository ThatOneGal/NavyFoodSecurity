<?php

namespace App\Http\Controllers;

use App\Models\OrderContent;
use Illuminate\Http\Request;

class OrderContentController extends Controller
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

        return view('Order.OrderingForm');

    }

    /**
     * Store a newly created resource in storage.
     *
     * @param  \Illuminate\Http\Request  $request
     * @return \Illuminate\Http\Response
     */
    public function store(Request $request)
    {
        //

    }

    /**
     * Display the specified resource.
     *
     * @param  \App\Models\OrderContent  $orderContent
     * @return \Illuminate\Http\Response
     */
    public function show(OrderContent $orderContent)
    {
        //
    }

    /**
     * Show the form for editing the specified resource.
     *
     * @param  \App\Models\OrderContent  $orderContent
     * @return \Illuminate\Http\Response
     */
    public function edit(OrderContent $orderContent)
    {
        //
    }

    /**
     * Update the specified resource in storage.
     *
     * @param  \Illuminate\Http\Request  $request
     * @param  \App\Models\OrderContent  $orderContent
     * @return \Illuminate\Http\Response
     */
    public function update(Request $request, OrderContent $orderContent)
    {
        //
    }

    /**
     * Remove the specified resource from storage.
     *
     * @param  \App\Models\OrderContent  $orderContent
     * @return \Illuminate\Http\Response
     */
    public function destroy(OrderContent $orderContent)
    {
        //
    }
}
