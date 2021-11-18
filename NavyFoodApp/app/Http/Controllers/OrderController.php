<?php

namespace App\Http\Controllers;

use App\Models\Location;
use App\Models\Order;
use App\Models\Status;
use App\Models\User;
use Illuminate\Http\Request;
use Illuminate\Support\Facades\Auth;
use Illuminate\Support\Facades\DB;

class OrderController extends Controller
{
    /**
     * Display a listing of the resource.
     *
     */
    public function index()
    {
        $locationList = Location::all();
        $statusList = Status::all();
        $orderList = Order::all();

        return view('Order.Index', compact('orderList', 'locationList', 'statusList'));
    }

    /**
     * Show the form for creating a new resource.
     */
    public function create()
    {
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
        $locationList = Location::all();
        $statusList = Status::all();

        $Order = new Order();
        $Order->fill($request->all());
        $Order->CustomerId = Auth::id();

        $Order->StatusId = 1;
        $Order->OrderDate = now();

        $Order->save();
        return view('Order.Show', compact('Order', 'locationList', 'statusList'));

    }

    /**
     * Display the specified resource.
     *
     */

    public function show(Order $Order)
    {
        $locationList = Location::all();
        $statusList = Status::all();

        if ($Order == null)
            $Order = Order::latest()->first();


        return view('Order.Show', compact('Order', 'locationList', 'statusList'));
    }
/*
    public function showByID(int $orderNum)
    {
        $view = DB::table('orders')
            ->where('id', $orderNum)
            ->get();

        $locationList = Location::all();
        $statusList = Status::all();

        return view('showByID', compact('view', 'locationList', 'statusList'));

    }*/
    public function showByID(Request $request)
    {

        (int) $id = $request->id;
        $Order = Order::find($id);
        if (!$Order) {
            abort(404);
        }

        $locationList = Location::all();
        $statusList = Status::all();

        return view('Order.Show', compact('Order', 'locationList', 'statusList'));

    }

    public function last()
    {
        $locationList = Location::all();
        $statusList = Status::all();
        $Order = Order::latest()->first();


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
        return view('Order.Edit', compact('Order', 'locationList', 'statusList'));
    }

    /**
     * Update the specified resource in storage.
     */
    public function update(Request $request, Order $order)
    {
        $user = User::find(Auth::id());
        $order->fill($request->all());

        if ($user->UserRoleId == 3) {
            $order->StatusId = 11;
            $order->PackerId = Auth::id();
            $order->OrderPacked = date('Y-m-d H:i:s');
        }
        if ($user->UserRoleId == 4) {
            $order->StatusId = 12;
            $order->DriverId = Auth::id();
            $order->OrderShipped = date('Y-m-d H:i:s');
        }

        if ($order->OrderPacked == null && $user->UserRoleId == 4) {
            echo "<script>alert('This order has not been packed yet.');</script>";

        }
        else{
            $order->save();

        }



        return redirect(route('order.index'));

    }

    /**
     * Remove the specified resource from storage.
     *
     */
    public function destroy(Order $order)
    {
        //

        $order->delete();
        return redirect(route('order.index'));


    }

}
