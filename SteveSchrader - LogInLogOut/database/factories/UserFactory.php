<?php

namespace Database\Factories;

use App\Models\Team;
use App\Models\User;
use Illuminate\Database\Eloquent\Factories\Factory;
use Illuminate\Support\Str;
use Laravel\Jetstream\Features;

class UserFactory extends Factory
{
    /**
     * The name of the factory's corresponding model.
     *
     * @var string
     */
    protected $model = User::class;

    /**
     * Define the model's default state.
     *
     * @return array
     */
    public function definition()
    {
        return [
            'id' => $this->faker->id(),
            'service_number' => $this->faker->service_number(),
            'rank' => $this->faker->rank(),
            'first_name' => $this->faker->firstname(),
            'last_name' => $this->faker->lastName(),
            'admin' => false,
            'password' => '$2y$10$92IXUNpkjO0rOQ5byMi.Ye4oKoEa3Ro9llC/.og/at2.uheWG/igi',
        ];
    }

    /**
     *  Define this user model as administrator
     */
    public function admin()
    {
        return $this->state([
            'admin' => true
    ]);
    }
}
