<?php

namespace App\Models {

    use Illuminate\Database\Eloquent\Model;
    use Laravel\Sanctum\HasApiTokens;
    use Illuminate\Notifications\Notifiable;
    use Illuminate\Database\Eloquent\Factories\HasFactory;

    class User extends \Illuminate\Foundation\Auth\User
    {
        use HasApiTokens;
        use HasFactory;
        use Notifiable;

        protected $table = "users";
        protected $primaryKey = "id";
        public $incrementing = true;

        /**
         * The attributes that are mass assignable.
         *
         * @var array
         */
        protected $fillable = [
            'id',
            'service_number',
            'rank',
            'first_name',
            'last_name',
            'admin',
            'password',
        ];
    }
}
