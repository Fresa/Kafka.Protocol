git config --global credential.helper store
Add-Content "$env:USERPROFILE\.git-credentials" "https://$($env:git_access_token):x-oauth-basic@github.com`n"
git config --global user.email "fresa@fresa.se"
git config --global user.name "Fredrik Arvidsson"
git tag v$($env:APPVEYOR_BUILD_VERSION) $($env:APPVEYOR_REPO_COMMIT)
git push origin --tags --quiet