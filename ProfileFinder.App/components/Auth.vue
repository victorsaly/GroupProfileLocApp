<template>
  <div>
    <h3 class="display-1 mb-5">
      Firebase Authentication
    </h3>
    <div class="links">
      <form v-if="!isLoggedIn">
        <h5>SignUp / LogIn</h5>
        <input
          v-model="formData.email"
          color="primary"
          outlined
          placeholder="Email"
          type="email"
          autocomplete="username"
        >
        <input
          v-model="formData.password"
          color="primary"
          outlined
          placeholder="Password"
          type="password"
          autocomplete="current-password"
        >
        <button
          type="button"
          color="primary"
          outlined
          @click="createUser()"
        >
          Register
        </button>
        <button
          type="button"
          color="primary"
          outlined
          @click="signInUser()"
        >
          Sign In
        </button>
      </form>
      <div v-else>
        <p>You are logged in with {{ authUser.email }}.</p>
        <button color="primary" outlined @click="logout">
          Logout
        </button>
      </div>
    </div>
  </div>
</template>

<script>
import { mapState, mapGetters } from 'vuex'
export default {
  data: () => ({
    formData: {
      email: '',
      password: ''
    }
  }),
  computed: Object.assign(Object.assign({}, mapState({
    authUser: state => state.authUser
  })), mapGetters({
    isLoggedIn: 'isLoggedIn'
  })),
  methods: {
    async createUser () {
      try {
        await this.$fireAuth.createUserWithEmailAndPassword(this.formData.email, this.formData.password)
      } catch (e) {
        alert('demo' + e)
      }
    },
    async signInUser () {
      try {
        await this.$fireAuth.signInWithEmailAndPassword(this.formData.email, this.formData.password)
        alert('passed')
      } catch (e) {
        alert('signInUser error:' + e)
      }
    },
    async logout () {
      try {
        await this.$fireAuth.signOut()
      } catch (e) {
        alert(e)
      }
    }
  }
}

</script>
