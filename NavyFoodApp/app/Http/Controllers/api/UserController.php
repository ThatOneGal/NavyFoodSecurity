<?php

namespace App\Http\Controllers\api;

use App\Http\Controllers\Controller;
use App\Models\User;
use Illuminate\Http\Request;
use Illuminate\Support\Facades\Hash;


class UserController extends Controller
{
    //
    public function index()
    {
        $modelList = User::all();

        return response()->json($modelList, 200);
    }

    public function store(Request $request)
    {
        //

        $modelList = new User();
        $modelList->fill($request->all());
        $modelList->password = Hash::make($request->password);

        $modelList->save();
        return response()->json($modelList, 201);

    }

    public function show($id)
    {
        $model = User::find($id);
        if (!$model) {
            abort(404);
        }

        return response()->json($model, 200);

    }
    public function update(Request $request, $id)
    {

        $model = User::find($id);
        if (!$model) {
            abort(404);
        }
        $model->update($request->all());

        $model->save();
        return response()->json($model, 200);

    }
    public function destroy($id)
    {
        //
        $model = Order::find($id);
        if (!$model) {
            abort(404);
        }
        $model->delete();
        return response()->json(null,204);
    }

}
