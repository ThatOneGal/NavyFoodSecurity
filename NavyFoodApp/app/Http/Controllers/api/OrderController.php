<?php

namespace App\Http\Controllers\api;

use App\Http\Controllers\Controller;
use App\Models\Order;
use Illuminate\Database\Eloquent\Model;
use Illuminate\Http\Request;

class OrderController extends Controller
{
    public function index()
    {
        $orderList = Order::all();

        return response()->json($orderList, 200);
    }


    /**
     * Store a newly created resource in storage.
     *
     */
    public function store(Request $request)
    {
        //

        $Order = new Order();
        $Order->fill($request->all());

        $Order->StatusId = 1;
        $Order->OrderDate = now();


        $Order->save();
        return response()->json($Order, 201);

    }



    /**
     * Display the specified resource.
     *
     */
    public function show($id)
    {
        $Order = Order::find($id);
        if (!$Order) {
            abort(404);
        }

        return response()->json($Order, 200);

    }

    /**
     * Update the specified resource in storage.
     *

     */
    public function update(Request $request, $id)
    {

        $Order = Order::find($id);
        if (!$Order) {
            abort(404);
        }
        $Order->update($request->all());

        $Order->save();
        return response()->json($Order, 200);

    }

    /**
     * Remove the specified resource from storage.
     *
     */
    public function destroy($id)
    {
        //
        $Order = Order::find($id);
        if (!$Order) {
            abort(404);
        }
        $Order->delete();
        return response()->json(null,204);
    }
}
