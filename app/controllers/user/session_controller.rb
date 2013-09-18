class User::SessionController < User::HomeController
	before_filter :user_is_signed_in, only: [ :destroy ]
	before_filter :user_isnt_signed_in, only: [ :new, :create ]

	def user_is_signed_in
		redirect_to(user_signin_path) if !current_user
	end

	def user_isnt_signed_in
		redirect_to(root_path) if current_user
	end


	def new
	end

	def create
		stuff = params[:login]
		user = User.authenticate(stuff[:identifier], stuff[:password])
		if user != nil
			expire = 2.weeks.from_now
			expire = 69.years.from_now if stuff[:rememberme]

			user_session = Session.new(expired: false, expires_at: expire, owner_ip: '', location: '', user_agent: '', user_id: user.id)
			user_session.save!

			session[:session_id] = user_session.identifier
			redirect_to(root_path)
		else
			@error = 'Incorrect Password or Username/Email Address'
			@identifier = stuff[:identifier]
			render 'user/session/new'
		end
	end

	def destroy
		session[:identifier] = nil
		reset_session

		redirect_to(root_path)
	end
end
